﻿using FluentPOS.Shared.Core.Wrapper;
using MediatR;
using System;

namespace FluentPOS.Modules.Catalog.Core.Features.Categories.Commands
{
    public class RemoveCategoryCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; }

        public RemoveCategoryCommand(Guid categoryId)
        {
            Id = categoryId;
        }
    }
}