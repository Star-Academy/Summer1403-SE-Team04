using System.Runtime.CompilerServices;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Reader;

namespace FullTextSearchTest.Controllers.Logic;

public class SmallWordsRemoverTest
{ [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Read_ShouldBeStringEmpty_IfPathIsNullOrEmpty(params string[] list)
    {
        Assert.Equal(new SmallWordsRemover().Remove(list),new List<string>());
    }
    [Fact]
    public void Read_ShouldBeSpilitedList_IfPathIsNormal()
    {
        Assert.Equal(new []{"ali","mamad","is"},new SmallWordsRemover().Remove(new []{"ali","mamad","doing","is"}));
    }
}