using Assets.Scripts.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Database.Controllers
{
    public class OptionFacade
    {
        public static List<Option> FindAll()
        {
            return Facade<Option>.FindAll();
        }

        public static Option Find(Option item)
        {
            IEnumerable<Option> query = from Option t in DBContext.LocalDB
                                        where t.Equals(item)
                                        select t;

            Option result = query.SingleOrDefault();

            return result;
        }

        public static Option Find(string optionName)
        {
            Option o = Find(Option.GetDefault(optionName));
            
            return o ?? Option.GetDefault(optionName);
        }

        public static bool Save(Option option)
        {
            return Facade<Option>.Save(option);
        }
        
        public static bool Save(string name, Enum value)
        {
            Option o = Find(name);
            o.Value = value;

            return Save(o);
        }

        public static void Delete(Option option)
        {
            Facade<Option>.Delete(option);
        }

        public static void DeleteAll()
        {
            List<Option> options = FindAll();

            foreach(Option o in options)
            {
                Delete(o);
            }
        }

        public static void UnlockLevel(UnlockedLevelOption unlockedLevel)
        {
            Option oUnlockedLevel = OptionFacade.Find(OptionName.UnlockedLevel);
            oUnlockedLevel.Value = unlockedLevel;

            OptionFacade.Save(oUnlockedLevel);
        }
    }
}
