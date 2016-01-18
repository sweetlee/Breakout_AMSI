using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Database.Controllers
{
    public static class Facade<T>
    {
        public static List<T> FindAll()
        {
            return DBContext.LocalDB.LoadAll<T>().ToList();
        }

        public static T Find(T item)
        {
            IEnumerable<T> query = from T t in DBContext.LocalDB
                                   where t.Equals(item)
                                   select t;

            T result = query.FirstOrDefault();

            return result;
        }

        internal static bool Save(T item)
        {
            try
            {
                DBContext.LocalDB.StoreObject(item);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return true;
        }

        internal static void Delete(T item)
        {
            DBContext.LocalDB.Delete(item);
        }

        public static void ToStringAll()
        {
            string result = string.Empty;
            List<T> data = FindAll();
            //Debug.Log(scores.Count);
            data.Sort();

            for (int i = 0; i < data.Count; ++i)
            {
                //Debug.LogFormat("{0},{1}", "i=", i);
                result += String.Format("{0}.\t{1}\n", i + 1, data[i].ToString());
            }

            Debug.Log(result.Equals(String.Empty) ? "Brak danych" : result);
        }
    }
}
