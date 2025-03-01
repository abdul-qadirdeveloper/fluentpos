﻿using System;
using FluentPOS.Modules.People.Core.Entities;
using FluentPOS.Shared.Core.Features.ExtendedAttributes.Commands.Validators;
using Microsoft.Extensions.Localization;

namespace FluentPOS.Modules.People.Core.Features.ExtendedAttributes.Validators.Carts
{
    public class RemoveCartExtendedAttributeCommandValidator : RemoveExtendedAttributeCommandValidator<Guid, Cart>
    {
        public RemoveCartExtendedAttributeCommandValidator(IStringLocalizer<RemoveCartExtendedAttributeCommandValidator> localizer) : base(localizer)
        {
            // you can override the validation rules here
        }
    }
}