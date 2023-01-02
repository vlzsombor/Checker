using AngleSharp.Css.Dom;
using AngleSharp.Dom;
using Moq;
using System.Linq;
using Checker.Client;
namespace BlazorTest;

public class CheckerTest : TestContext
{
    [Fact]
    public void TableCellCount()
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>();

        var tr = cut.FindAll("tr");
        var td = cut.FindAll("td");
        //var xd = b.First() as ;
        Assert.Equal(8, tr.Count);
        Assert.Equal(8 * 8, td.Count);
    }


    [Fact]
    public void TableCellColorCheck()
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>();

        var tds = cut.FindAll("tr:nth-child(2n) td:nth-child(2n+1)");

        foreach (var td in tds)
        {

            var dfads = td.CreateStyleSheets();

            var a = td.ComputeCurrentStyle();

            var b = td.GetStyle();
            var c = td.GetStyleSheets();


            //var xdf = ch2.First();
            //var bo = ch.Any(x => x.ClassList.Any(x => x == "black"));
            //var ch2 = td.ChildNodes.First().ChildNodes.First().ChildNodes;

        }

        //var xd = b.First() as ;
        Assert.Equal(8 * 8, tds.Count);
    }

}
