﻿using FluentPOS.Shared.Core.Contracts;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;

namespace FluentPOS.Shared.Core.Features.ExtendedAttributes.Commands.Validators
{
    public abstract class RemoveExtendedAttributeCommandValidator<TEntityId, TEntity> : AbstractValidator<RemoveExtendedAttributeCommand<TEntityId, TEntity>>
        where TEntity : class, IEntity<TEntityId>
    {
        protected RemoveExtendedAttributeCommandValidator(IStringLocalizer localizer)
        {
            RuleFor(request => request.Id)
                .NotEqual(Guid.Empty).WithMessage(x => localizer["The {PropertyName} property cannot be empty."]);
        }
    }
}