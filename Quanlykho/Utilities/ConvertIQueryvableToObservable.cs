using System.Collections.ObjectModel;
using System.Linq;

namespace Quanlykho.Utilities
{
    public static class ConvertIQueryvableToObservable
    {
        public static void GetObservableCollection<T>(this IQueryable<T> query, ObservableCollection<T> values)
        {
            foreach (var item in query)
            {
                values.Add(item);
            }
        }
    }
}