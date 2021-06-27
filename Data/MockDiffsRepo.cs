using System;
using System.Collections.Generic;
using System.Linq;
using Diffing.Models;
using Diffing.Utils;


namespace Diffing.Data
{
    public class MockDiffsRepo : IDiffsRepo  //implementation of interface
    {
        public Dictionary<int, Pair> Data { get; set; }

        public MockDiffsRepo()
        {
            Data = new Dictionary<int, Pair>();
        }

        public void CreatePair(Pair pair)
        {
            if (Data.ContainsKey(pair.Id))
            {
                if (pair.Left != null)
                    Data[pair.Id].Left = pair.Left;
                if (pair.Right != null)
                    Data[pair.Id].Right = pair.Right;
            }
            else
            {
                Data.Add(pair.Id, pair);
            }
        }

        public bool DoesDataExist()
        {
            if (GetAllData().Count() == 0)
                return false;

            return true;
        }

        public List<Pair> GetAllData()
        {
            return Data.Values.ToList();
        }

        public Pair GetPair(int id)
        {
            if (Data.ContainsKey(id))
                return Data[id];

            return null;
        }

        public Result GetResults(Pair pair)
        {
            return CalculateDiffs.getResult(pair);
        }

        public bool PairDoesExist(int id)
        {
            return Data.ContainsKey(id);
        }

        public bool SaveChanges()
        {
            return true;
        }
    }
}