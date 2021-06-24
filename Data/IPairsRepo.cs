using System.Collections.Generic;
using base64diffs.Models;

namespace base64diffs.Data
{
    //interface 
    public interface IPairsRepo
    {
        Result GetDiffs(int id);
        Pair GetPair(int id);
        Pair PutLeft(int id);
        Pair PutRight(int id);

    }
}