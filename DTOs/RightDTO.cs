using System.ComponentModel.DataAnnotations;

namespace base64diffs.DTOs
{
    public class RightCreateDTO
    {
        [Required]
        public string data { get; set; }

    }
}