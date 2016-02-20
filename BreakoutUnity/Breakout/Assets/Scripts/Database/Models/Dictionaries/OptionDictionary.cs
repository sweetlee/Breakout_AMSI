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
        Level_1 = 1,
        Level_2,
        Level_3,
        Level_4,
        Level_5,
        Level_6,
        Level_7,
        Level_8,
        Level_9,
        Level_10,
        Level_11,
        Level_12,
        Level_13,
        Level_14,
        Level_15,
        Level_16,
        Level_17,
        Level_18,
        Level_19,
        Level_20
    }
}
