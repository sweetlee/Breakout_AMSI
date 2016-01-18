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
                    result = OptionDefault.Controls;
                    break;
                case OptionName.Music:
                    result = OptionDefault.Music;
                    break;
                case OptionName.Sound:
                    result = OptionDefault.Sound;
                    break;
                case OptionName.UnlockedLevel:
                    result = OptionDefault.UnlockedLevel;
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
