using System.ComponentModel.DataAnnotations;

namespace Infraestructure.Models
{
    public class Request<T> where T : class
    {
        [Required]
        public T Body { get; set; } = null!;
        public List<string>? Tags { get; set; }
    }
}
