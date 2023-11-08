namespace DynamicMenu.Application.Common.Exceptions
{
    public class NotUrlException : Exception
    {
        public NotUrlException(string name, string link) : base($"Property {name} must be valid URL! {link} is not correct URL") { } 
    }
}
