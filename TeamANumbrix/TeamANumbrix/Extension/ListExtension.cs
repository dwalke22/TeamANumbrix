using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeamANumbrix.Extension
{
    /// <summary>
    ///     The List Extension class
    /// </summary>
    public static class ListExtension
    {
        #region Methods

        /// <summary>
        ///     Converts a list to on observable collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }

        #endregion
    }
}