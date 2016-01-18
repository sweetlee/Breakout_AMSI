using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Models
{
    public static class OptionName
    {
        public const string Controls = "Controls";
        public const string Music = "Music";
        public const string Sound = "Sound";
        public const string UnlockedLevel = "UnlockedLevel";
    }

    public static class OptionDefault
    {
        public static Option Controls = new Option() { Name = OptionName.Controls, Value = ControlOption.Arrows };
        public static Option Music = new Option() { Name = OptionName.Music, Value = OnOffOption.On };
        public static Option Sound = new Option() { Name = OptionName.Sound, Value = OnOffOption.On };
        public static Option UnlockedLevel = new Option() { Name = OptionName.Controls, Value = UnlockedLevelOption.Level01 };
    }

    public enum ControlOption
    {
        Arrows = 0,
        Paddle,
        Gyroscope
    }

    public enum OnOffOption
    {
        Off = 0,
        On = 1
    }

    public enum UnlockedLevelOption
    {
        Level01 = 1,
        Level02,
        Level03,
        Level04,
        Level05,
        Level06,
        Level07,
        Level08,
        Level09,
        Level10,
        Level11,
        Level12,
        Level13,
        Level14,
        Level15,
        Level16,
        Level17,
        Level18,
        Level19,
        Level20
    }
}
