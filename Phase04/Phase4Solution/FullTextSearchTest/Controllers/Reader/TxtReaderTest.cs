using FullTextSearch.Controllers.Reader;

public class TxtReaderTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Read_ShouldBeStringEmpty_IfPathIsNullOrEmpty(string path)
    {
        Assert.Equal(new TxtReader().Read(path),new List<string>());
    }
    [Fact]
    public void Read_ShouldBeSpilitedList_IfPathIsNormal()
    {
        Assert.Equal(new TxtReader().Read("D:\\Desktop\\programing\\C#\\Summer1403-SE-Team04\\Phase04\\Phase4Solution\\FullTextSearchTest\\AssetTest\\TxtReadFileTest.txt"),new string[]{"ali","reza"});
    }
}