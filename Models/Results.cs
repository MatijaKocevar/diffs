using System.Collections.Generic;

namespace base64diffs.Models
{
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