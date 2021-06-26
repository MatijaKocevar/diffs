using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace base64diffs.Models
{
    //this is where I'll store base64 data
    public class Pair
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }

    }
}