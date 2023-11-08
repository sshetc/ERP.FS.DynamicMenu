using System.Text.Json.Serialization;

namespace DynamicMenu.Domain
{
    public class MenuItem
    {
        [JsonIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Link { get; set; }
    }
}