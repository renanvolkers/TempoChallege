namespace Tempo.Knight.Domain.Model
{
    public class KnightAttribute
    {
        public Guid KnightId { get; set; }
        public  Knight? Knight { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute? Attribute { get; set; }

    }
}
