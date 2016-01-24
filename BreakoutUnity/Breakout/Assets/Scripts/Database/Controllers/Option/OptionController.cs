using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Models
{
    public partial class Option : IComparable, IEquatable<Option>
    {
        public int CompareTo(object obj)
        {
            Option c = (Option)obj;
            return Name.CompareTo(c.Name);
        }

        public bool Equals(Option other)
        {
            if (other == null)
                return false;

            return Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, Value);
        }

        public static Option GetDefault(string name)
        {
            Option result;

            switch(name)
            {
                case OptionName.Controls:
                    result = new Option() { Name = OptionName.Controls, Value = ControlOption.Arrows };
                    break;
                case OptionName.Music:
                    result = new Option() { Name = OptionName.Music, Value = OnOffOption.On };
                    break;
                case OptionName.Sound:
                    result = new Option() { Name = OptionName.Sound, Value = OnOffOption.On };
                    break;
                case OptionName.UnlockedLevel:
                    result = new Option() { Name = OptionName.UnlockedLevel, Value = UnlockedLevelOption.Level_1 };
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}