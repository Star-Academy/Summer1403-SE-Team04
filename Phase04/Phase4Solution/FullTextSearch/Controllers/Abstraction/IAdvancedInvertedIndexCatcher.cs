using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Abstraction;

public interface IAdvancedInvertedIndexCatcher
{
    void Write(AdvancedInvertedIndex index);
    List<AdvancedInvertedIndex>? Load();
}