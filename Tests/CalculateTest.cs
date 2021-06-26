using System;
using System.Collections.Generic;
using System.Diagnostics;
using base64diffs.Models;
using Newtonsoft.Json;
using Xunit;

public class TestClass
{
    [Fact]
    public void IsCalculationOfDiffsCorrect()
    {

        Pair pair = new Pair();

        pair.Id = 3;
        pair.Left = "AAAAAA==";
        pair.Right = "AQABAQ==";


        Result test = new Result();
        test.diffResultType = "ContentDoNotMatch";
        test.diffs = new List<Diff>();
        Diff diff1 = new Diff();
        Diff diff2 = new Diff();


        diff1.Offset = 0;
        diff1.Length = 1;
        test.diffs.Add(diff1);
        diff2.Offset = 2;
        diff2.Length = 2;
        test.diffs.Add(diff2);

        var expected = JsonConvert.SerializeObject(test);
        var actual = JsonConvert.SerializeObject(base64diffs.Utils.CalculateDiffs.getResult(pair));


        Assert.Equal(expected, actual);
    }


}