using System;
using System.Collections.Generic;
using base64diffs.Models;

namespace base64diffs.Data
{
    //implementation of interface
    public class MockPairsRepo : IDiffsRepo
    {
        public void CreatePair(Pair pair)
        {
            throw new NotImplementedException();
        }

        public Result GetResults(Pair pair)
        {
            throw new NotImplementedException();
        }

        public Pair GetPair(int id)
        {
            throw new NotImplementedException();
        }

        public bool PairDoesExist(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}