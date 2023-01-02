using AngleSharp.Css.Dom;
using AngleSharp.Dom;
using Moq;
using System.Linq;
using Checker.Client;
using System;

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
    /// Checker: circle color shape.
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
    /// Checker: clicking event
    /// </summary>
    [Theory]
    [InlineData("5-0","4-1")]
    [InlineData("5-2","4-1")]
    [InlineData("5-2","4-3")]
    //[InlineData("2-7","3-6")]
    public void TableClickValidationGeneral2(string withCheckerRowId, string destinationRowId)
    {
        // Arrange
        var cut = RenderComponent<Checkerboard>(p => p.Add(p => p.IsWhitePlayer, true));

        cut.WaitForElement($"#cellId{withCheckerRowId} #cellWithChecker", TimeSpan.FromSeconds(1));
        cut.WaitForElement($"#cellId{destinationRowId}", TimeSpan.FromSeconds(10));
        
        var rowWithChecker = cut.Find($"#cellId{withCheckerRowId} #cellWithChecker");
        Assert.Contains("checker", rowWithChecker.OuterHtml);
        //Act
        rowWithChecker.Click();
        // Destination row
        cut.Find($"#cellId{destinationRowId}").Click();
        var rowToValidate = cut.Find($"#cellId{withCheckerRowId}");
        Assert.DoesNotContain("checker", rowToValidate.OuterHtml);
    }
}
