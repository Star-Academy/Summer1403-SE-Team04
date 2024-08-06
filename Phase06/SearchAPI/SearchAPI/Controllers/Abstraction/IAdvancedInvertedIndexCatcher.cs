using SearchAPI.Model.DataStructure;

namespace SearchAPI.Controllers.Abstraction;

public interface IAdvancedInvertedIndexCatcher
{
    bool Write(AdvancedInvertedIndex index);
    List<AdvancedInvertedIndex>? Load();
}