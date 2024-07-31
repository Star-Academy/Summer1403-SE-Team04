using FullTextSearch.Controllers.Logic;

namespace FullTextSearchTest.Controllers.Logic;

public class MathHelperTest
{
    [Fact]
    public void Union_ShouldBeStringEmpty_IfListIsEmpty()
    {
        var list = new List<List<int>>();
        Assert.Equal(Array.Empty<int>(), list.Union());
    }

    [Fact]
    public void Union_ShouldBeUnionedList_IfNormalInput()
    {
        var list = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 2, 3, 4 },
            new() { 3, 4, 5 }
        };
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, list.Union());
    }

    [Fact]
    public void InterSect_ShouldBeStringEmpty_IfListIsEmpty()
    {
        var list = new List<List<int>>();
        Assert.Equal(Array.Empty<int>(), list.Intersect());
    }

    [Fact]
    public void Intersect_ShouldBeIntersectedList_IfNormalInput()
    {
        var list = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 2, 3, 4 },
            new() { 3, 4, 5 }
        };
        Assert.Equal(new List<int> { 3 }, list.Intersect());
    }
}