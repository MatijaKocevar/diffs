using System;
using System.Collections.Generic;
using Diffing.Models;

namespace Diffing.Utils
{
    public class CalculateDiffs
    {
        public static Result getResult(Pair pair)
        {
            Result results = new Result();
            results.diffs = new List<Diff>();

            //converts base64 string to an array of 8-bit unsigned integers
            byte[] L = Convert.FromBase64String(pair.Left);
            byte[] R = Convert.FromBase64String(pair.Right);


            //check if lenghts are the same...if not return result type
            if (L.Length != R.Length)
            {
                results.diffResultType = "SizeDoNotMatch";
                return results;
            }
            //check if data is identical..if it is return result type
            else if (pair.Left == pair.Right)
            {
                results.diffResultType = "Equals";
                return results;
            }

            //diffs found...use algorithm
            int length = 0;
            int offset = 0;

            results.diffResultType = "ContentDoNotMatch";


            for (int i = 0; i < L.Length; i++)
            {
                //perform XOR operation between individual bytes..XOR tells if there was a change on individual byte
                int xor = L[i] ^ R[i];


                bool isByteDifferent = xor != 0;
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
    }
}