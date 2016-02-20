using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.Controllers;
using System;
using System.Collections.Generic;
using Assets.Scripts.Database;

public class OptionControllerTest
{

    [SetUp]
    public void Init()
    {

    }

    [Test]
    [Category("CompareTo")]
    public void CompareToSameValue([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string option, [Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string comparer)
    {
        Option o = new Option() { Name = option, Value = OnOffOption.On };
        Option c = new Option() { Name = comparer, Value = OnOffOption.On };

        int result = o.CompareTo(c);
        int expected = option.CompareTo(comparer);


        Assert.AreEqual(expected, result);
    }

    [Test]
    [Category("CompareTo")]
    public void CompareToDiffrentValue([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string option, [Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string comparer)
    {
        Option o = new Option() { Name = option, Value = OnOffOption.On };
        Option c = new Option() { Name = comparer, Value = OnOffOption.Off };

        int result = o.CompareTo(c);
        int expected = option.CompareTo(comparer);


        Assert.AreEqual(expected, result);
    }

    [Test]
    [Category("Equals")]
    public void EqualsSameValue([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string option, [Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string comparer)
    {
        Option o = new Option() { Name = option, Value = OnOffOption.On };
        Option c = new Option() { Name = comparer, Value = OnOffOption.On };

        bool result = o.Equals(c);
        bool expected = option.Equals(comparer);


        Assert.AreEqual(expected, result);
    }

    [Test]
    [Category("Equals")]
    public void EqualsDiffrentValue([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string option, [Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string comparer)
    {
        Option o = new Option() { Name = option, Value = OnOffOption.On };
        Option c = new Option() { Name = comparer, Value = OnOffOption.Off };

        bool result = o.Equals(c);
        bool expected = option.Equals(comparer);


        Assert.AreEqual(expected, result);
    }

    [Test]
    [Category("Equals")]
    public void GetDefault([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string option)
    {
        Option o = Option.GetDefault(option);

        Option expected;

        switch (option)
        {
            case OptionName.Controls:
                expected = new Option() { Name = OptionName.Controls, Value = ControlOption.Arrows };
                break;
            case OptionName.Music:
                expected = new Option() { Name = OptionName.Music, Value = OnOffOption.On };
                break;
            case OptionName.Sound:
                expected = new Option() { Name = OptionName.Sound, Value = OnOffOption.On };
                break;
            case OptionName.UnlockedLevel:
                expected = new Option() { Name = OptionName.UnlockedLevel, Value = UnlockedLevelOption.Level_1 };
                break;
            default:
                expected = null;
                break;
        }


        Assert.AreEqual(expected.Name, o.Name);
        Assert.AreEqual(expected.Value, o.Value);
    }
}
