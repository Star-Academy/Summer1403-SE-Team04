using FullTextSearch.Controllers.Abstraction;
using FullTextSearch.Controllers.Logic.Abstraction;
using FullTextSearch.Controllers.Logic.Creator_Loader;
using FullTextSearch.Model.DataStructure;
using NSubstitute;

namespace FullTextSearchTest.Controllers.Logic;

public class AdvanceInvertedIndexCreatorTest 
{
    private readonly AdvanceInvertedIndexCreator _sut;
    private IDocCatcher _docCatcher;
    private IAdvancedInvertedIndexCatcher _advancedInverted;
    public AdvanceInvertedIndexCreatorTest()
    {
        _docCatcher = Substitute.For<IDocCatcher>();
        _advancedInverted = new AdvanceInvertedIndexCatcher();
        _sut = new AdvanceInvertedIndexCreator(_docCatcher,_advancedInverted);
    }
    [Fact]
    public void CreateAdvancedInvertedIndex_shouldCallDocCatcherLoad_ifCallTheMethod()
    {
        //arrange
        string path = "testPath";
        //action
        _sut.CreateAdvancedInvertedIndex(path);
        //assert
        _docCatcher.Received(1).Load();
    }
    [Fact]
    public void CreateAdvancedInvertedIndex_shouldCallAdvInvetedIndexWriteMethod_ifCallTheMethod()
    {
        //arrange
        string path = "testPath";
        //action
        _sut.CreateAdvancedInvertedIndex(path);
        //assert
        _advancedInverted.Received(1).Write(Arg.Any<AdvancedInvertedIndex>());
    }
}