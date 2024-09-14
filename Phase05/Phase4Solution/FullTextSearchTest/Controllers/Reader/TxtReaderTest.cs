using FullTextSearch.Controllers.Reader;

namespace FullTextSearchTest.Controllers.Reader;

public class TxtReaderTest
{
    private readonly TxtReader _sut;

    public TxtReaderTest()
    {
        _sut = new TxtReader();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Read_ShouldReturnStringEmpty_IfPathIsNullOrEmpty(string path)
    {
        // Arrange 
        var expected = new List<string>();
        // Act
        var actual = _sut.Read(path);
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Read_ShouldReturnSpilitedList_IfPathIsNormal()
    {
        // Arrange 
        var expected = new[] { "ali", "reza" };
        // Act
        var actual = _sut.Read("AssetTest\\TxtReadFileTest.txt");
        // Assert
        Assert.Equal(expected, actual);
    }
}