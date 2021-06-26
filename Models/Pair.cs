using System.ComponentModel.DataAnnotations.Schema;

namespace base64diffs.Models
{
    //representation of data within our application
    //this is our model for storing left and right data (base64 strings)
    public class Pair
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //atribute to allow setting ID-s manually
        public int Id { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }

    }
}