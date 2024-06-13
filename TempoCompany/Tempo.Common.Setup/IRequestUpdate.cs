namespace Tempo.Common.Setup
{

    /// <summary>
    /// Interface Goals use SOLID LISP
    /// Only for update
    /// </summary>
    public interface IRequestUpdate:IRequest
    {

        public Guid Id { get; set; }
    }
}
