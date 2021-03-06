using System.Collections.Generic;
using Diffing.Models;

namespace Diffing.Data
{
    //interface defenition 
    public interface IDiffsRepo
    {
        List<Pair> GetAllData();
        bool DoesDataExist();
        Result GetResults(Pair pair);
        Pair GetPair(int id);
        bool PairDoesExist(int id);
        void CreatePair(Pair pair);
        bool SaveChanges();


    }
}