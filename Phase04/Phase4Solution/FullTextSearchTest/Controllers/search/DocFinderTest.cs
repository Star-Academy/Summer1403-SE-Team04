using FullTextSearch.Controllers.Logic;
using FullTextSearch.Controllers.Logic.DocumentsLoader;
using FullTextSearch.Controllers.Reader;
using FullTextSearch.Controllers.search;
using FullTextSearch.Model.DataStructure;

namespace FullTextSearchTest.Controllers.search;

public class DocFinderTest
{
    private readonly DocFinder _docFinder;
    private readonly InvertedIndex _index;

    public DocFinderTest()
    {
        var path = "/home/sadq/RiderProjects/Star/Summer1403-SE-Team04/Phase03/FullTextSearch/Assets/files";
        new InvertedIndexCreator(new InvertedIndexWriter(), new DocumentLoader(new DocBuilder(new TxtReader()), new SmallWordsRemover())).CreateInvertedIndex(path);
        _index = new InvertedIndexLoader().Load()?.Last();
        _docFinder = new DocFinder(_index);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("awordthatdoesntexist")]
    [InlineData("dream")]
    [InlineData("expense")]
    public void Find_ShouldReturnExpectedResults(string query)
    {
        // Act
        var result = _docFinder.Find(query);

        // Assert
        if (string.IsNullOrEmpty(query) || !_index.InvertedIndexMap.ContainsKey(query))
        {
            Assert.Empty(result);
        }
        else
        {
            Assert.NotEmpty(result);
            Assert.Equal(_index.InvertedIndexMap[query], result);
        }
    }
}