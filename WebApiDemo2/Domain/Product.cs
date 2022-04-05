using System.ComponentModel.DataAnnotations;

namespace WebApiDemo2.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage ="{0} must be {1} characters in length")]
        public string Name { get; set; }
    }
}
