using FullTextSearch.Controllers.Logic;

namespace FullTextSearchTest.Controllers.Logic;

public class SmallWordsRemoverTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Read_ShouldReturnStringEmpty_IfPathIsNullOrEmpty(params string[] list)
    {
        // Arrange
        var expected = new List<string>();
        // Act
        var actual = new SmallWordsRemover().Remove(list);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Read_ShouldReturnSpilitedList_IfPathIsNormal()
    {
        // Arrange
        var expected = new[] { "ali", "mamad", "is" };
        // Act
        var actual = new SmallWordsRemover().Remove(new[] { "ali", "mamad", "doing", "is" });
        // Assert
        Assert.Equal(expected, actual);
    }
}