using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Abstraction;

public interface IAdvancedInvertedIndexCatcher
{
    bool Write(AdvancedInvertedIndex index);
    List<AdvancedInvertedIndex>? Load();
}