namespace FullTextSearch.Control.Logic.DocumentsLoader;

public class WordsFormatFixer
{
    private WordsFormatFixer()
    {
    }

    private static WordsFormatFixer? _wordsFormatFixerInstance;
    public static WordsFormatFixer WordsFormatFixerInstance
    {
        get { return _wordsFormatFixerInstance ??= new WordsFormatFixer(); }
    }

    public List<string> FixWords(List<string> documentWords)
    {
        return documentWords.Select(w => w.FixWordFormat())
            .ToList().RemoveEmptyCells();
    }
}