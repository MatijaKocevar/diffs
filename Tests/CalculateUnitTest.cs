using System.Collections.Generic;
using Diffing.Models;
using Newtonsoft.Json;
using Xunit;

public class CalculationTestClass
{

    [Fact]
    public void IsCalculationOfDiffsCorrect()
    {
        //mock data LEFT & RIGHT
        Pair pair = new Pair();
        pair.Id = 3;
        pair.Left = "AAAAAA==";
        pair.Right = "AQABAQ==";

        Result test = new Result();
        test.diffs = new List<Diff>();

        test.diffResultType = "ContentDoNotMatch";
        Diff diff1 = new Diff { Offset = 0, Length = 1 };
        Diff diff2 = new Diff { Offset = 2, Length = 2 };
        test.diffs.Add(diff1);
        test.diffs.Add(diff2);

        //convert expected result to serialized JSON object
        var expected = JsonConvert.SerializeObject(test);
        //get result from app and convert to serialized JSON object
        var actual = JsonConvert.SerializeObject(Diffing.Utils.CalculateDiffs.getResult(pair));

        //compare and return result
        Assert.Equal(expected, actual);
    }


}