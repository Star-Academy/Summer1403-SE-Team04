namespace FullTextSearch.Controllers.Logic.Abstraction;

public interface IAdvanceInvertedIndexCatcher
{
    void Write(AdvanceInvertedIndex index);
    List<AdvanceInvertedIndex>? Load();
}