namespace FullTextSearch.Model.DataStructure.AbstractClass;

public abstract class WordInformation
{
   private string DocName { get; init; }

   protected WordInformation(string docName)
   {
      DocName = docName;
   }
}