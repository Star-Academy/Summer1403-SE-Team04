using System.Diagnostics.CodeAnalysis;
using static FullTextSearch.Controllers.Logic.MathHelper;
using FullTextSearch.Controllers.Logic;

namespace FullTextSearchTest.Controllers.Logic;

public class MathHelperTest
{ [Fact]
    public void Union_ShouldBeStringEmpty_IfListIsEmpty()
    {
        List<List<int>> list = new List<List<int>>();
        Assert.Equal(Array.Empty<int>(), list.Union());
    }
    [Fact]
    public void Union_ShouldBeUnionedList_IfNormalInput()
    {
        List<List<int>> list = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 2, 3, 4 },
            new List<int>() { 3, 4, 5 }
        };
        Assert.Equal(new List<int>(){1,2,3,4,5},list.Union());
    }
    [Fact]
    public void InterSect_ShouldBeStringEmpty_IfListIsEmpty()
    {
        List<List<int>> list = new List<List<int>>();
        Assert.Equal(Array.Empty<int>(), list.Intersect());
    }
    [Fact]
    public void  Intersect_ShouldBeIntersectedList_IfNormalInput()
    {
        List<List<int>> list = new List<List<int>>()
        {
            new List<int>() { 1, 2, 3 },
            new List<int>() { 2, 3, 4 },
            new List<int>() { 3, 4, 5 }
        };
        Assert.Equal(new List<int>(){3},list.Intersect());
    }

}