using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Abstraction;

public interface IAdvancedInvertedIndexCacher
{
    void Write(AdvancedInvertedIndex index);
    List<AdvancedInvertedIndex>? Load();
}