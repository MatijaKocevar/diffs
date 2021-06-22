using System.Collections.Generic;
using base64diffs.Models;

namespace base64diffs.Data
{
    //interface 
    public interface IPairsRepo
    {
        Result GetDiffByID(int id);
        Result PutLeft(int id);
        Result PutRight(int id);

    }
}