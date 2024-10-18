namespace HW_7
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CustomNameAttribute : Attribute
    {
        public string PropertyName { get; set; }
        public CustomNameAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}