using System;
using System.Collections.Generic;
using base64diffs.Data;
using base64diffs.Models;
using Microsoft.AspNetCore.Mvc;

namespace base64diffs.Controllers
{
    [Route("/v1/diff")]
    [ApiController]
    public class DiffsController : ControllerBase
    {
        // v1/diff/1
        [HttpGet("{id}")]
        public ActionResult<ResultType> GetDiffByID(int id)
        {
            //declare data and results
            Pair data = new Pair();
            Result results = new Result();

            //initialize List in class
            results.diffs = new List<Diff>();

            //data from example
            data.Id = id;
            data.Left = "AAAAAA==";
            data.Right = "AQABAQ==";



            byte[] A = Convert.FromBase64String(data.Left);
            byte[] B = Convert.FromBase64String(data.Right);

            //check if lenghts are the same...if not return result type
            if (A.Length != B.Length)
            {
                ResultType res = new ResultType();
                res.diffResultType = "SizeDoNotMatch";
                return res;
            }
            //check if data is identical..if it is return result type
            else if (data.Left == data.Right)
            {
                ResultType res = new ResultType();
                res.diffResultType = "Match";
                return res;
            }

            //diffs found...use algorithm
            int length = 0;
            int offset = 0;

            results.diffResultType = "ContentDoNotMatch";


            for (int i = 0; i < A.Length; i++)
            {
                //perform XOR operation between individual bytes..XOR tells if there was a change on individual byte
                int xor = A[i] ^ B[i];

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
                if ((!isByteDifferent && diffStarted) || (isByteDifferent && diffStarted && (i == A.Length - 1)))
                {
                    Diff pasteta = new Diff();
                    pasteta.Offset = offset;
                    pasteta.Length = length;
                    length = 0;
                    results.diffs.Add(pasteta);
                }
                //if the byte is different and it has no length..you found a diff
                if (isByteDifferent && (!diffStarted))
                {
                    offset = i;
                    length = length + 1;
                }


            }

            //return results..result type + diffs
            return Ok(results);
        }

    }
}