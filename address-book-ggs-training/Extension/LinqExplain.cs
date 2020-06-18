using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Extension
{
    public static class LinqExplain
    {
        public static T IlPrimoOIlPredefinito<T>(this IList<T> contacts, Func<T, bool> predicate)
        {
            for (var i = 0; i < contacts.Count; i++)
            {
                if (predicate(contacts[i]))
                {
                    return contacts[i];
                }
            }
            return default;
        }

        public static T IlPrimo<T>(this IList<T> contacts, Func<T, bool> predicate)
        {
            for (var i = 0; i < contacts.Count; i++)
            {
                if (predicate(contacts[i]))
                {
                    return contacts[i];
                }
            }
            throw new Exception();
        }
    }
}