using System.Collections.Generic;

namespace StudyCenter.Shared.Comum.Extensions
{
    public static class CollectionExtension
    {
        public static bool IsNullOrEmpty<T>(ICollection<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
