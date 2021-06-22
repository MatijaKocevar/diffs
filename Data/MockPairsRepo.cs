using System;
using System.Collections.Generic;
using base64diffs.Models;

namespace base64diffs.Data
{
    public class MockPairsRepo : IPairsRepo
    {
        //implementation of interface
        public Result GetDiffByID(int id)
        {
            throw new NotImplementedException();
        }

        public Result PutLeft(int id)
        {
            throw new NotImplementedException();
        }

        public Result PutRight(int id)
        {
            throw new NotImplementedException();
        }
    }
}