using System.ComponentModel.DataAnnotations;

namespace Diffing.DTOs
{
    public class RightCreateDTO
    {
        [Required]
        public string data { get; set; }

    }
}