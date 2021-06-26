using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace base64diffs.Models
{
    public class Left
    {
        [Required]
        public string data { get; set; }

    }

    public class Right
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

    //for returning different types of results
    public class ResultType
    {
        public string diffResultType { get; set; }
    }

    //Result will have a result type and a list of diffs
    public class Result
    {
        public string diffResultType { get; set; }
        public List<Diff> diffs { get; set; }
    }
}