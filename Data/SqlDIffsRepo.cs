using System;
using System.Collections.Generic;
using System.Linq;
using base64diffs.Models;

namespace base64diffs.Data
{
    public class SqlDiffsRepo : IPairsRepo
    {
        private readonly base64diffsContext _context;

        public SqlDiffsRepo(base64diffsContext context)
        {
            _context = context;
        }

        public Result GetDiffs(int id)
        {
            Result results = new Result();
            results.diffs = new List<Diff>();

            Pair pair = new Pair();

            pair = GetPair(id);

            Console.WriteLine("ID:" + pair.Id + " Left:" + pair.Left + " Right:" + pair.Right + pair);


            byte[] L = Convert.FromBase64String(pair.Left);
            byte[] R = Convert.FromBase64String(pair.Right);


            //check if lenghts are the same...if not return result type
            if (L.Length != R.Length)
            {
                Result res = new Result();
                res.diffResultType = "SizeDoNotMatch";
                return res;
            }
            //check if data is identical..if it is return result type
            else if (pair.Left == pair.Right)
            {
                Result res = new Result();
                res.diffResultType = "Equals";
                return res;
            }

            //diffs found...use algorithm
            int length = 0;
            int offset = 0;

            results.diffResultType = "ContentDoNotMatch";


            for (int i = 0; i < L.Length; i++)
            {
                //perform XOR operation between individual bytes..XOR tells if there was a change on individual byte
                int xor = L[i] ^ R[i];


                bool isByteDifferent = xor == 1;
                bool diffStarted = length > 0;

                //if the byte is different and if the diff has a length...length must increse as the diff is still continuing
                if (isByteDifferent && diffStarted)
                {
                    length = length + 1;

                }
                //if the byte is not different and it has length..you found the end of the diff and you should log it
                //or
                //if the byte is different and it has a length and you're positioned on the last item in the loop..you should log it
                if ((!isByteDifferent && diffStarted) || (isByteDifferent && diffStarted && (i == L.Length - 1)))
                {
                    Diff diff = new Diff();
                    diff.Offset = offset;
                    diff.Length = length;
                    length = 0;
                    results.diffs.Add(diff);
                }
                //if the byte is different and it has no length..you found a diff
                if (isByteDifferent && (!diffStarted))
                {
                    offset = i;
                    length = length + 1;
                }


            }
            //return results..result type + diffs
            return results;
        }

        public Pair GetPair(int id)
        {
            return _context.Pairs.FirstOrDefault(p => p.Id == id);
        }

        public Pair PutLeft(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pair PutRight(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}