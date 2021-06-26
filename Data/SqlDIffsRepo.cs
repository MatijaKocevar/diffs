using System;
using System.Collections.Generic;
using System.Linq;
using base64diffs.Models;
using base64diffs.Utils;


namespace base64diffs.Data
{
    public class SqlDiffsRepo : IDiffsRepo  //implementation of interface
    {
        private readonly base64diffsContext _context;

        public SqlDiffsRepo(base64diffsContext context)
        {
            _context = context;
        }

        //returns an object of type Result
        public Result GetResults(Pair pair)
        {
            return CalculateDiffs.getResult(pair);
        }

        //return an object of type Pair
        public Pair GetPair(int id)
        {
            return _context.Pairs.FirstOrDefault(p => p.Id == id);
        }

        //method for saving changes to database
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        //tells if pair exists in database
        public bool PairDoesExist(int id)
        {
            if (_context.Pairs.Any(o => o.Id == id))
            {
                return true;
            }
            return false;
        }

        //creates new pair in DBcontext
        public void CreatePair(Pair pair)
        {
            _context.Pairs.Add(pair);
        }
    }
}