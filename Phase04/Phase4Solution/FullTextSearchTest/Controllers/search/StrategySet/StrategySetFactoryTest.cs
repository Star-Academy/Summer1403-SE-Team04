using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search.StrategySet;

namespace FullTextSearchTest.Controllers.search.StrategySet;

public class StrategySetFactoryTest
{
    private readonly StrategySetFactory _sut;

    public StrategySetFactoryTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(), new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        var index = new InvertedIndexLoader().Load().Last();
        _sut = new StrategySetFactory(new []{"hey"}, index);
    }
    [Theory]
    [InlineData(StrategySetEnum.MustExist)]
    [InlineData(StrategySetEnum.MustNotExist)]
    [InlineData(StrategySetEnum.AtLeastOneExist)]
    public void Create_ShouldReturnValidStrategySet_WhereTheSetNameIsSame(StrategySetEnum setName)
    {
        Assert.Equal(_sut.Create(setName).GetName(), setName);
    }
}