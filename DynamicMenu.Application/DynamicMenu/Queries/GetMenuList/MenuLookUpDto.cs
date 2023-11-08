using DynamicMenu.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicMenu.Domain;
using AutoMapper;
using System.Text.Json.Serialization;

namespace DynamicMenu.Application.DynamicMenu.Queries.GetMenuList
{
    public class MenuLookUpDto : IMapWith<Menu>
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Component { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        [JsonIgnore]
        public string CompanyId { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Menu, MenuLookUpDto>();
        }

    }
}
