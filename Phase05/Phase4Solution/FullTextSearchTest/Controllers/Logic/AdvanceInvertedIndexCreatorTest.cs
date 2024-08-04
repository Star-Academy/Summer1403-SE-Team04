using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Model;
using FullTextSearch.Model.DataStructure;
using NSubstitute;

namespace FullTextSearchTest.Controllers.Logic;

public class AdvanceInvertedIndexCreatorTest
{
    private IDocumentLoader _documentLoader;
    private readonly AdvanceInvertedIndexCreator _sut;
    private IDocCatcher _docCatcher;
    private IAdvancedInvertedIndexCatcher _advancedInvertedIndexCatcher;
    public AdvanceInvertedIndexCreatorTest()
    {
        _docCatcher = Substitute.For<IDocCatcher>();
        _documentLoader = Substitute.For<IDocumentLoader>();
        _advancedInvertedIndexCatcher = Substitute.For<IAdvancedInvertedIndexCatcher>();
        _sut = new AdvanceInvertedIndexCreator(_docCatcher,_advancedInvertedIndexCatcher,_documentLoader);
    }
    [Fact]
    public void CreateAdvancedInvertedIndex_shouldCallDocCatcherLoad_ifCallTheMethod()
    {
        //arrange
        string path = "testPath";
        _docCatcher.Load().Returns(new List<Document>());
        _advancedInvertedIndexCatcher.Write(Arg.Any<AdvancedInvertedIndex>()).Returns(true);
        //action
        _sut.CreateAdvancedInvertedIndex(path);
        //assert
        _docCatcher.Received(1).Load();
    }
    [Fact]
    public void CreateAdvancedInvertedIndex_shouldCallAdvInvetedIndexWriteMethod_ifCallTheMethod()
    {
        //arrange
        var path = "testPath";
        _docCatcher.Load().Returns(new List<Document>());
        _advancedInvertedIndexCatcher.Write(Arg.Any<AdvancedInvertedIndex>()).Returns(true);
        //action
        _sut.CreateAdvancedInvertedIndex(path);
        //assert
        _advancedInvertedIndexCatcher.Received(1).Write(Arg.Any<AdvancedInvertedIndex>());
    }
}