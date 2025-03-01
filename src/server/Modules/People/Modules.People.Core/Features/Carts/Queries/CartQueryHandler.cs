﻿using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentPOS.Modules.People.Core.Abstractions;
using FluentPOS.Modules.People.Core.Entities;
using FluentPOS.Modules.People.Core.Exceptions;
using FluentPOS.Shared.Core.Extensions;
using FluentPOS.Shared.Core.Wrapper;
using FluentPOS.Shared.DTOs.People.Carts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace FluentPOS.Modules.People.Core.Features.Carts.Queries
{
    internal class CartQueryHandler :
        IRequestHandler<GetAllPagedCartsQuery, PaginatedResult<GetAllPagedCartsResponse>>,
        IRequestHandler<GetCartByIdQuery, Result<GetCartByIdResponse>>
    {
        private readonly IPeopleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CartQueryHandler> _localizer;

        public CartQueryHandler(
            IPeopleDbContext context,
            IMapper mapper,
            IStringLocalizer<CartQueryHandler> localizer)
        {
            _context = context;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<PaginatedResult<GetAllPagedCartsResponse>> Handle(GetAllPagedCartsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Cart, GetAllPagedCartsResponse>> expression = e => new GetAllPagedCartsResponse(e.Id, e.CustomerId, e.Timestamp);
            var queryable = _context.Carts.AsQueryable();

            if (request.OrderBy?.Any() == true)
            {
                var ordering = string.Join(",", request.OrderBy);
                queryable = queryable.OrderBy(ordering);
            }
            else
            {
                queryable = queryable.OrderBy(a => a.Id);
            }

            if (request.CustomerId != null && !request.CustomerId.Equals(Guid.Empty)) queryable = queryable.Where(x => x.CustomerId.Equals(request.CustomerId));
            if (!string.IsNullOrEmpty(request.SearchString))
            {
                //TODO - add some searching logic if needed
                //queryable = queryable.Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{request.SearchString.ToLower()}%")
                //|| EF.Functions.Like(x.Detail.ToLower(), $"%{request.SearchString.ToLower()}%")
                //|| EF.Functions.Like(x.Id.ToString().ToLower(), $"%{request.SearchString.ToLower()}%"));
            }
            var cartList = await queryable
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            if (cartList == null) throw new PeopleException(_localizer["Carts Not Found!"], HttpStatusCode.NotFound);
            var mappedCarts = _mapper.Map<PaginatedResult<GetAllPagedCartsResponse>>(cartList);
            return mappedCarts;
        }

        public async Task<Result<GetCartByIdResponse>> Handle(GetCartByIdQuery query, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.AsNoTracking().Where(c => c.Id == query.Id).FirstOrDefaultAsync(cancellationToken);
            if (cart == null) throw new PeopleException(_localizer["Cart Not Found!"], HttpStatusCode.NotFound);
            var mappedCart = _mapper.Map<GetCartByIdResponse>(cart);
            return await Result<GetCartByIdResponse>.SuccessAsync(mappedCart);
        }
    }
}