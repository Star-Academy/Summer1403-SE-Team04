
using FullTextSearch.Controllers.Logic.Abstraction;

namespace FullTextSearch.Controllers.Logic.StringProcessor;
public  class ToLower : IStringReformater
{
    private static ToLower _lower;
    public static ToLower Instance => _lower ??= new ToLower();
    public string FixWordFormat(string word)
    {
        return word.ToLower();
    }
}