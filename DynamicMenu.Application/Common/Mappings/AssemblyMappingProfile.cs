using AutoMapper;
using System.Reflection;

namespace DynamicMenu.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) => ApplyMappingsFromAssembly(assembly);
        private void ApplyMappingsFromAssembly(Assembly assembly) 
        {
            // Получаем все типы, которые были наследованы от IMapWith<T>
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)));

            // Во всех этих типах вызываем метод Mapping, наследованный от IMapWith<T>
            foreach (var type in types) 
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });

            }
        } 
    }
}
