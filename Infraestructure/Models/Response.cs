namespace Infraestructure.Models
{
    public class Response<T>
    {
        public T? Body { get; set; }
        public List<string>? Errors { get; set; }
    }
}
