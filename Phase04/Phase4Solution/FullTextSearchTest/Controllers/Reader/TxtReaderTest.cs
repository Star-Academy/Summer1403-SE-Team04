using FullTextSearch.Controllers.Reader;

namespace FullTextSearchTest.Controllers.Reader;

public class TxtReaderTest
{
    private TxtReader _sut;

    public TxtReaderTest()
    {
        _sut = new TxtReader();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]

    public void Read_ShouldBeStringEmpty_IfPathIsNullOrEmpty(string path)
    {
        //arrange 
        var result = new List<string>();
        //act
        var check = _sut.Read(path);
        //assert
        Assert.Equal(result,check);
    }

    [Fact]
    public void Read_ShouldBeSpilitedList_IfPathIsNormal()
    {
        //arrange 
        var result = new[] { "ali", "reza" };
        //act
        var check = _sut.Read("AssetTest\\TxtReadFileTest.txt");
        //assert
        Assert.Equal(result, check);
    }
}