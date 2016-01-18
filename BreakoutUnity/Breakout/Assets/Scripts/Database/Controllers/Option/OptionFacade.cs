using Assets.Scripts.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Controllers
{
    public class OptionFacade
    {
        public static List<Option> FindAll()
        {
            return Facade<Option>.FindAll();
        }

        public static Option Find(string optionName)
        {
            Option o = Facade<Option>.Find(Option.GetDefault(optionName));

            return o ?? Option.GetDefault(optionName);
        }

        public static bool Save(Option option)
        {
            return Facade<Option>.Save(option);
        }
        
        public static bool Save(string name, Enum value)
        {
            //if(value is ControlOption)
            return Save(new Option() { Name = name, Value = value });
        }

        public static void Delete(Option option)
        {
            Facade<Option>.Delete(option);
        }
    }
}
