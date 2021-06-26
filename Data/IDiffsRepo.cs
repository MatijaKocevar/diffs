using System.Collections.Generic;
using base64diffs.Models;

namespace base64diffs.Data
{
    //interface defenition 
    public interface IDiffsRepo
    {
        Result GetDiffs(Pair pair);
        Pair GetPair(int id);
        bool PairDoesExist(int id);
        void CreatePair(Pair pair);
        bool SaveChanges();


    }
}