using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenu.Application.DynamicMenu.Queries.GetMenuList
{
    public class GetMenuListQuery : IRequest<MenuListVm>
    {
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
