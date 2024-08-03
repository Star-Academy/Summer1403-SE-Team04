using FullTextSearch.Model.DataStructure;

namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IAdvancedInvertedIndexCatcher
{
    void Write(AdvancedInvertedIndex index);
    List<AdvancedInvertedIndex>? Load();
}