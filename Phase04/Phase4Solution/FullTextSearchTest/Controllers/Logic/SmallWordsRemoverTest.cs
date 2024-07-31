using FullTextSearch.Controllers.Logic;

namespace FullTextSearchTest.Controllers.Logic;

public class SmallWordsRemoverTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Read_ShouldBeStringEmpty_IfPathIsNullOrEmpty(params string[] list)
    {
        Assert.Equal(new SmallWordsRemover().Remove(list), new List<string>());
    }

    [Fact]
    public void Read_ShouldBeSpilitedList_IfPathIsNormal()
    {
        //arrange
        var check = new[] { "ali", "mamad", "is" };
        //act
        var result = new SmallWordsRemover().Remove(new[] { "ali", "mamad", "doing", "is" });
        //assert
        Assert.Equal(check,result);
    }
}