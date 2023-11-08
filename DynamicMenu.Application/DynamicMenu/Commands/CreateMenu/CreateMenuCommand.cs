using AutoMapper;
using DynamicMenu.Application.Common.Mappings;
using DynamicMenu.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenu.Application.DynamicMenu.Commands.CreateMenu
{
    public class CreateMenuCommand : IRequest<string>, IMapWith<Menu>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Component { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMenuCommand, Menu>();
        }

    }
}
