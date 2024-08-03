namespace FullTextSearch.Model.AbstractClass;

public abstract class WordInformation
{
   public string DocName { get; init; }

   protected WordInformation(string docName)
   {
      DocName = docName;
   }
}