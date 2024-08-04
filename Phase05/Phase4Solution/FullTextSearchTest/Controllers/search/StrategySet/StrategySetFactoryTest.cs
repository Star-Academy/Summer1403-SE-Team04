using FullTextSearch;
using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Controllers.search.StrategySet;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search.StrategySet;

public class StrategySetFactoryTest
{
    private readonly StrategySetFactory _sut;

    public StrategySetFactoryTest()
    {
        Dictionary<string, List<string>> testDic = new Dictionary<string, List<string>>()
        {
            {"love", new List<string>() { "location" }}
        };
         var index = new InvertedIndex(testDic, "location");
        _sut = new StrategySetFactory(new[] { "hey" }, new DocFinder(index));
    }

    [Theory]
    [InlineData(StrategySetEnum.MustExist)]
    [InlineData(StrategySetEnum.MustNotExist)]
    [InlineData(StrategySetEnum.AtLeastOneExist)]
    public void Create_ShouldReturnValidStrategySet_WhereTheSetNameIsSame(StrategySetEnum setName)
    {
        // Arrange
        // Act
        var name = _sut.Create(setName).GetName();
        // Assert
        Assert.Equal(setName, name);
    }
}