using System.ComponentModel.DataAnnotations;

namespace base64diffs.DTOs
{
    public class LeftCreateDTO
    {
        [Required]
        public string data { get; set; }

    }
}