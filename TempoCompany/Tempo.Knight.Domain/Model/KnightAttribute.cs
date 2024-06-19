namespace Tempo.Knight.Domain.Model
{
    public class KnightAttribute
    {
        public Guid KnightId { get; set; }
        public required Knight Knight { get; set; }
        public Guid AttributeId { get; set; }
        public required Attribute Attribute { get; set; }
        public int Value { get; set; }
    }
}
