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

    public static class OptionToggle
    {
        public const string Sound = "SoundToggle";
        public const string Arrow = "ArrowToggle";
        public const string Paddle = "PaddleToggle";
        public const string Gyroscope = "GyroscopeToggle";
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
