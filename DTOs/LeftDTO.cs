using System.ComponentModel.DataAnnotations;

namespace Diffing.DTOs
{
    public class LeftCreateDTO
    {
        [Required]
        public string data { get; set; }

    }
}