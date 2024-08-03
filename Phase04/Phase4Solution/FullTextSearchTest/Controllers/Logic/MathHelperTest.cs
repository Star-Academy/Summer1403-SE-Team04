using FullTextSearch.Controllers.Logic;

namespace FullTextSearchTest.Controllers.Logic;

public class MathHelperTest
{
    [Fact]
    public void Union_ShouldReturnStringEmpty_IfListIsEmpty()
    {
        // Arrange
        var list = new List<List<int>>();
        var expected = Array.Empty<int>();
        // Act
        var actual = list.Union();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Union_ShouldReturnUnionedList_IfNormalInput()
    {
        
        // Arrange
        var actualList = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 2, 3, 4 },
            new() { 3, 4, 5 }
        };
        var expected = new List<int> { 1, 2, 3, 4, 5 };
        // Act
        var actual = actualList.Union();
        // Assert
        
        Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, actual);
    }

    [Fact]
    public void InterSect_ShouldReturnStringEmpty_IfListIsEmpty()
    {
        
        // Arrange
        var list = new List<List<int>>();
        var expected = Array.Empty<int>();
        // Act
        var actual = list.Intersect();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Intersect_ShouldReturnIntersectedList_IfNormalInput()
    {
        // Arrange
        var actualList = new List<List<int>>
        {
            new() { 1, 2, 3 },
            new() { 2, 3, 4 },
            new() { 3, 4, 5 }
        };
        var expected = new List<int> { 3 };
        // Act
        var actual = actualList.Intersect();
        // Assert
        
        Assert.Equal(expected, actual);
    }
}