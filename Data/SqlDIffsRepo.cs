using System;
using System.Collections.Generic;
using System.Linq;
using base64diffs.Models;
using base64diffs.Utils;

namespace base64diffs.Data
{
    public class SqlDiffsRepo : IPairsRepo
    {
        private readonly base64diffsContext _context;

        public SqlDiffsRepo(base64diffsContext context)
        {
            _context = context;
        }

        public Result GetDiffs(Pair pair)
        {
            return CalculateDiffs.getResult(pair);
        }

        public Pair GetPair(int id)
        {
            return _context.Pairs.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool PairDoesExist(int id)
        {
            if (_context.Pairs.Any(o => o.Id == id))
            {
                return true;
            }
            return false;
        }

        public void CreatePair(Pair pair)
        {
            _context.Pairs.Add(pair);
        }
    }
}