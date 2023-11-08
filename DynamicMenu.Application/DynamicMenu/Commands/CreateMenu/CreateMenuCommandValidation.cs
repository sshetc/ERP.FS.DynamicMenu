using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenu.Application.DynamicMenu.Commands.CreateMenu
{
    public class CreateMenuCommandValidation : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidation()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.CompanyId).NotEmpty().NotNull();
        }
    }
}
