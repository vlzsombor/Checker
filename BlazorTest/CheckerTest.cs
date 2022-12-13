using AngleSharp.Css.Dom;
using AngleSharp.Dom;
using Checker.Client;
using Microsoft.AspNetCore.SignalR.Client;
using Moq;
using System;
using System.Linq;

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

    /// <summary>
    /// Checker: circle round shape.
    /// </summary>
    [Fact]
    public void TableCellColorCheck()
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>();

        var cellsWithChecker = cut.FindAll("#cellWithChecker");

        var whites = cellsWithChecker.Take(12);

        Assert.All(whites, c => Assert.True(c.Children.Single().ClassList.Contains("black")));

        var blacks = cellsWithChecker.TakeLast(12);
        Assert.All(blacks, c => Assert.True(c.Children.Single().ClassList.Contains("white")));
    }

    /// <summary>
    /// Checker: circle round shape.
    /// </summary>
    [Fact]
    public void TableCellColorCheck2()
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>(p => p.Add(p => p.IsWhitePlayer, true));



        cut.WaitForElement("#cellId5-0 #cellWithChecker", TimeSpan.FromSeconds(10));
        cut.WaitForElement("#cellId4-1", TimeSpan.FromSeconds(10));

        var a = cut.Find("#cellId5-0 #cellWithChecker");
        //var stepOpportunity = cut.Find("#41");
        a.Click();
        //blackChecker.Click();
        //stepOpportunity.Click();

        var op = cut.Find("#cellId4-1");
        cut.Find("#cellId4-1").Click();
        //cut.Render();

        var b = cut.Find("#cellId4-1");
        var xd = cut.Find("#cellId5-0");

        //cut.Find("cellId{i}-{j}")

    }


    [Fact]
    public void TableCellColorCheck3()
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>();

        var a = cut.Find("#testid");
        cut.Find("#testid button").Click();
        cut.Find("#testid button").Click();
        cut.Find("#testid button").Click();
        //var stepOpportunity = cut.Find("#41");
        var b = cut.Find("#testid");
        //await cut.InvokeAsync(()=>cut.);

    }

}
