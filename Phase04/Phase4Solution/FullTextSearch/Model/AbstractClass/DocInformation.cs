namespace FullTextSearch.Model.AbstractClass;

public abstract class DocInformation
{
   public string DocName { get; init; }

   protected DocInformation(string docName)
   {
      DocName = docName;
   }
}