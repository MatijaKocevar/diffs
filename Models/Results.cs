using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace base64diffs.Models
{
    //class for storing data from input
    public class Left
    {
        [Required]
        public string data { get; set; }

    }
    //class for storing data from input
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

    //for only different types of results
    public class ResultType
    {
        public string diffResultType { get; set; }
    }

    //for result type and a list of diffs
    public class Result
    {
        public string diffResultType { get; set; }
        public List<Diff> diffs { get; set; }
    }
}