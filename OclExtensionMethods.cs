using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Collections.Concurrent;

namespace OclExtensions
{
    public static class OclExtensionMethods
    {
        #region Integer Extension Methods
        public static int Max(this int i, int i2) => i > i2 ? i : i2;
        public static int Min(this int i, int i2) => i < i2 ? i : i2;
        public static int Div(this int i, int i2) => i / i2;
        public static int Mod(this int i, int i2) => i % i2;
        public static int Abs(this int i) => Math.Abs(i);
        #endregion

        #region Real Extension Methods
        public static double Max(this double r, double r2) => r > r2 ? r : r2;
        public static double Min(this double r, double r2) => r < r2 ? r : r2;
        public static double Abs(this double r) => Math.Abs(r);
        public static double Floor(this double r) => Math.Floor(r);
        public static double Round(this double r) => Math.Round(r);

        // Not in OCL Grammatik
        public static double Ceiling(this double r) => Math.Ceiling(r);
        #endregion

        #region String Extension Methods
        public static int Size(this string s) => s.Length;
        public static string Concat(this string s, string s2) => string.Concat(s, s2);
        public static int ToInt(this string s)
        {
            _ = Int32.TryParse(s, out int number);
            return number;
        }
        public static double ToReal(this string s)
        {
            double number;
            NumberStyles style = NumberStyles.AllowDecimalPoint;
            CultureInfo cultureEn = CultureInfo.CreateSpecificCulture("en-En");
            CultureInfo cultureFr = CultureInfo.CreateSpecificCulture("fr-Fr");
            if (Double.TryParse(s, style, cultureEn, out number))
                return number;
            else
            {
                _ = Double.TryParse(s, style, cultureFr, out number);
                return number;
            }
        }
        #endregion

        #region List Extension Methods
        public static int Size<T>(this List<T> list) => list.Count;
        public static bool Excludes<T>(this List<T> list, T obj) => !list.Contains(obj);
        public static int Count<T>(this List<T> list, T obj)
        {
            int count = 0;
            foreach (T e in list)
                if (e.Equals(obj))
                    count++;
            return count;
        }
        public static bool IncludesAll<T>(this List<T> list, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (!list.Contains(e2))
                    return false;
            return true;
        }
        public static bool ExcludesAll<T>(this List<T> list, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (list.Contains(e2))
                    return false;
            return true;
        }
        public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
        public static bool NotEmpty<T>(this List<T> list) => list.Count > 0;
        public static List<T> SubSequence<T>(this List<T> list, int i1, int i2) => list.GetRange(i1, i2 - i1);
        public static T At<T>(this List<T> list, int i) => list[i];
        public static List<T> Including<T>(this List<T> list, T obj)
        {
            List<T> result = new List<T>(list)
            {
                obj
            };
            return result;
        }
        public static List<T> Excluding<T>(this List<T> list, T obj)
        {
            List<T> result = new List<T>(list);
            result.Remove(obj);
            return result;
        }
        public static List<T> Reject<T>(this List<T> list, Predicate<T> e)
        {
            List<T> result = new List<T>(list);
            result.RemoveAll(e);
            return result;
        }
        public static List<T> UnionOcl<T>(this List<T> list, IEnumerable<T> collection) => new List<T>(list.Union(collection));
        public static ConcurrentBag<T> AsBag<T>(this List<T> list) => new ConcurrentBag<T>(list);

        // Not finished yet
        public static bool IsUnique<T>(this List<T> list, T obj)
        {
            return true;
        }
        public static List<T> SortedBy<T>(this List<T> list, T obj)
        {
            return list;
        }
        #endregion

        #region Set Extension Methods
        public static int Size<T>(this HashSet<T> st) => st.Count;
        public static bool IsEmpty<T>(this HashSet<T> st) => st.Count == 0;
        public static bool NotEmpty<T>(this HashSet<T> st) => st.Count > 0;
        public static bool Excludes<T>(this HashSet<T> st, T obj) => !st.Contains(obj);
        public static int Count<T>(this HashSet<T> st, T obj)
        {
            int count = 0;
            foreach (T e in st)
                if (e.Equals(obj))
                    count++;
            return count;
        }
        public static bool IncludesAll<T>(this HashSet<T> st, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (!st.Contains(e2))
                    return false;
            return true;
        }
        public static bool ExcludesAll<T>(this HashSet<T> st, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (st.Contains(e2))
                    return false;
            return true;
        }
        public static HashSet<T> Including<T>(this HashSet<T> st, T obj)
        {
            HashSet<T> result = new HashSet<T>(st)
            {
                obj
            };
            return result;
        }
        public static HashSet<T> Excluding<T>(this HashSet<T> st, T obj)
        {
            HashSet<T> result = new HashSet<T>(st);
            result.Remove(obj);
            return result;
        }
        public static HashSet<T> Reject<T>(this HashSet<T> st, Predicate<T> e)
        {
            HashSet<T> result = new HashSet<T>(st);
            result.RemoveWhere(e);
            return result;
        }
        public static HashSet<T> UnionOcl<T>(this HashSet<T> st, IEnumerable<T> collection) => new HashSet<T>(st.Union(collection));
        public static HashSet<T> Intersection<T>(this HashSet<T> st, IEnumerable<T> collection) => new HashSet<T>(st.Intersect(collection));
        public static ConcurrentBag<T> AsBag<T>(this HashSet<T> st) => new ConcurrentBag<T>(st);
        #endregion

        #region Bag Extension Methods
        public static int Size<T>(this ConcurrentBag<T> bg) => bg.Count;
        public static bool IsEmpty<T>(this ConcurrentBag<T> bg) => bg.Count == 0;
        public static bool NotEmpty<T>(this ConcurrentBag<T> bg) => bg.Count > 0;
        public static bool Excludes<T>(this ConcurrentBag<T> bg, T obj) => !bg.Contains(obj);
        public static bool IncludesAll<T>(this ConcurrentBag<T> bg, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (!bg.Contains(e2))
                    return false;
            return true;
        }
        public static bool ExcludesAll<T>(this ConcurrentBag<T> bg, IEnumerable<T> collection)
        {
            foreach (var e2 in collection)
                if (bg.Contains(e2))
                    return false;
            return true;
        }
        public static int Count<T>(this ConcurrentBag<T> bg, T obj)
        {
            int count = 0;
            foreach (T e in bg)
                if (e.Equals(obj))
                    count++;
            return count;
        }
        public static ConcurrentBag<T> Including<T>(this ConcurrentBag<T> bg, T obj)
        {
            ConcurrentBag<T> result = new ConcurrentBag<T>(bg)
            {
                obj
            };
            return result;
        }
        public static ConcurrentBag<T> Excluding<T>(this ConcurrentBag<T> bg, T obj)
        {
            ConcurrentBag<T> result = new ConcurrentBag<T>();
            while (bg.TryTake(out T temp))
            {
                if (temp.Equals(obj))
                    continue;
                else
                    result.Add(temp);
            }
            return result;
        }
        public static ConcurrentBag<T> UnionOcl<T>(this ConcurrentBag<T> bg, IEnumerable<T> collection) => new ConcurrentBag<T>(bg.Union(collection));
        public static ConcurrentBag<T> Intersection<T>(this ConcurrentBag<T> bg, IEnumerable<T> collection) => new ConcurrentBag<T>(bg.Intersect(collection));

        #endregion
    }
}
