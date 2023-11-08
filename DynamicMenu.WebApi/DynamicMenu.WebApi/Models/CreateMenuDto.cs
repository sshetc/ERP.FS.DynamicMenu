using AutoMapper;
using DynamicMenu.Application.Common.Mappings;
using DynamicMenu.Application.DynamicMenu.Commands.CreateMenu;
using DynamicMenu.Domain;
using System.Text.Json.Serialization;

namespace DynamicMenu.WebApi.Models
{
    public class CreateMenuDto : IMapWith<CreateMenuCommand>
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Component { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMenuDto, CreateMenuCommand>();
        }
    }
}
