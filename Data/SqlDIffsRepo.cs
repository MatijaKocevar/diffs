using System;
using System.Collections.Generic;
using System.Linq;
using Diffing.Models;
using Diffing.Utils;


namespace Diffing.Data
{
    public class SqlDiffsRepo : IDiffsRepo  //implementation of interface
    {
        private readonly DiffingContext _context;

        public SqlDiffsRepo(DiffingContext context)
        {
            _context = context;
        }

        //returns all data in database
        public List<Pair> GetAllData()
        {
            return _context.Pairs.ToList();
        }

        public bool DoesDataExist()
        {
            if (_context.Pairs.Count() == 0)
                return false;

            return true;
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