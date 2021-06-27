using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diffing.Models
{
    public class Base64Input
    {
        [Required]
        public string data { get; set; }
    }
    //this is for storing a single diff
    public class Diff
    {
        public int Offset { get; set; }
        public int Length { get; set; }

    }

    //for result type and a list of diffs
    public class Result
    {
        public string diffResultType { get; set; }
        public List<Diff> diffs { get; set; }
    }
}