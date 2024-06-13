[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public class DescriptionAttribute : Attribute
{

    /// <summary>
    /// It is used in Enum's dataanotation to facilitate the use of description
    /// </summary>
    public string Description { get; }

    public DescriptionAttribute(string description)
    {
        Description = description;
    }
}