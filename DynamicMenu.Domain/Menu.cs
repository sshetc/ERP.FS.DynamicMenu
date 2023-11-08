using System.Text.Json.Serialization;
namespace DynamicMenu.Domain
{
    public class Menu
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Component { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public List<MenuItem> Items { get; set; } = new ();
    }
}


