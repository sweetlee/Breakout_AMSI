﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Assets.Scripts.Database.Models;
using Assets.Scripts.Database.Controllers;
using System;
using System.Collections.Generic;
using Assets.Scripts.Database;

public class OptionTest {

    [SetUp]
    public void Init()
    {
        OptionFacade.DeleteAll();
        //DBContext.Delete();
    }

    [Test]
    [Category("Find")]
    public void FindAll()
    {
        //Arrange
        List<Option> database;

        //Act
        OptionFacade.Save(OptionName.Controls, ControlOption.Paddle);
        OptionFacade.Save(OptionName.UnlockedLevel, UnlockedLevelOption.Level_12);

        database = OptionFacade.FindAll();

        Option control = OptionFacade.Find(OptionName.Controls);
        Option unlockedLevel = OptionFacade.Find(OptionName.UnlockedLevel);

        //Assert
        Assert.Contains(control ,database);
        Assert.Contains(unlockedLevel, database);
        Assert.AreEqual(2, database.Count, Facade<Option>.ToStringAll());
    }

    [Test]
    [Category("Find")]
    public void FindOption([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string name)
    {
        //Arrange
        Option option = OptionFacade.Find(name);

        //Act

        //Assert
        Assert.IsNotNull(option);
    }

    [Test]
    [Category("Find")]
    public void FindDefaultOption([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string name)
    {
        //Arrange
        Option database = OptionFacade.Find(name);
        Option defaultOption = Option.GetDefault(name);

        //Act


        //Assert
        Assert.AreEqual(defaultOption, database);
    }

    [Test]
    [Category("Save")]
    public void SaveControlOptionDirect([Values(ControlOption.Arrows, ControlOption.Paddle, ControlOption.Gyroscope)]ControlOption value)
    {
        //Arrange
        Option database = OptionFacade.Find(OptionName.Controls);
        Option saved;

        //Act
        database.Value = value;
        OptionFacade.Save(database);
        saved = OptionFacade.Find(OptionName.Controls);

        //Assert
        Assert.AreEqual(database, saved);
        Assert.AreEqual(database.Value, saved.Value);
        Assert.AreEqual(1, OptionFacade.FindAll().Count, Facade<OptionFacade>.ToStringAll());
    }

    [Test]
    [Category("Save")]
    public void SaveControlOption([Values(ControlOption.Arrows, ControlOption.Paddle, ControlOption.Gyroscope)]ControlOption value)
    {
        //Arrange
        Option toSave = new Option() { Name = OptionName.Controls, Value = value };
        Option saved;

        //Act
        OptionFacade.Save(toSave.Name, toSave.Value);
        saved = OptionFacade.Find(OptionName.Controls);

        //Assert
        Assert.AreEqual(toSave, saved);
        Assert.AreEqual(toSave.Value, saved.Value);
        Assert.AreEqual(1, OptionFacade.FindAll().Count, Facade<Option>.ToStringAll());
    }

    [Test]
    [Category("Save")]
    public void SaveSoundOption([Values(OnOffOption.On, OnOffOption.Off)]OnOffOption value)
    {
        //Arrange
        Option toSave = new Option() { Name = OptionName.Sound, Value = value };
        Option saved;

        //Act
        OptionFacade.Save(toSave.Name, toSave.Value);
        saved = OptionFacade.Find(OptionName.Sound);

        //Assert
        Assert.AreEqual(toSave, saved);
        Assert.AreEqual(toSave.Value, saved.Value);
        Assert.AreEqual(1, OptionFacade.FindAll().Count, Facade<Option>.ToStringAll());
    }

    [Test]
    [Category("Save")]
    public void SaveUnlockedLevelOption([Values(UnlockedLevelOption.Level_1, UnlockedLevelOption.Level_16, UnlockedLevelOption.Level_8)]UnlockedLevelOption value)
    {
        //Arrange
        Option toSave = new Option() { Name = OptionName.Sound, Value = value };
        Option saved;

        //Act
        OptionFacade.Save(toSave.Name, toSave.Value);
        saved = OptionFacade.Find(OptionName.Sound);

        //Assert
        Assert.AreEqual(toSave, saved);
        Assert.AreEqual(toSave.Value, saved.Value);
        Assert.AreEqual(1, OptionFacade.FindAll().Count, Facade<Option>.ToStringAll());
    }

    [Test]
    [Category("Save")]
    public void SaveSoundOptionDirect([Values(OnOffOption.On, OnOffOption.Off)]OnOffOption value)
    {
        //Arrange
        Option database = OptionFacade.Find(OptionName.Sound);
        Option saved;

        //Act
        database.Value = value;
        OptionFacade.Save(database);
        saved = OptionFacade.Find(OptionName.Sound);

        //Assert
        Assert.AreEqual(database, saved, "Object");
        Assert.AreEqual(database.Value, saved.Value, "Value");
        Assert.AreEqual(1, OptionFacade.FindAll().Count, Facade<Option>.ToStringAll());
    }

    [Test]
    [Category("Save")]
    public void SaveUnlockedLevelOptionDirect([Values(UnlockedLevelOption.Level_1, UnlockedLevelOption.Level_16, UnlockedLevelOption.Level_8)]UnlockedLevelOption value)
    {
        //Arrange
        Option database = OptionFacade.Find(OptionName.UnlockedLevel);
        Option saved;

        //Act
        database.Value = value;
        OptionFacade.Save(database);
        saved = OptionFacade.Find(OptionName.UnlockedLevel);

        //Assert
        Assert.AreEqual(database, saved);
        Assert.AreEqual(database.Value, saved.Value);
    }

    [Test]
    [Category("Delete")]
    public void DeleteAll()
    {
        //Arrange
        List<Option> database;

        //Act
        OptionFacade.Save(OptionName.Controls, ControlOption.Paddle);
        OptionFacade.Save(OptionName.Sound, OnOffOption.Off);
        OptionFacade.Save(OptionName.UnlockedLevel, UnlockedLevelOption.Level_12);

        database = OptionFacade.FindAll();

        //Assert
        Assert.IsNotEmpty(database);

        //Act
        OptionFacade.DeleteAll();
        database = OptionFacade.FindAll();

        //Assert
        Assert.IsEmpty(database);
    }

    [Test]
    [Category("Delete")]
    public void Delete([Values(OptionName.Controls, OptionName.Sound, OptionName.UnlockedLevel)] string name)
    {
        //Arrange
        Option option = OptionFacade.Find(name);
        List<Option> database;

        //Act
        OptionFacade.Save(OptionName.Controls, ControlOption.Paddle);
        OptionFacade.Save(OptionName.Sound, OnOffOption.Off);
        OptionFacade.Save(OptionName.UnlockedLevel, UnlockedLevelOption.Level_12);
        
        OptionFacade.Save(option);

        database = OptionFacade.FindAll();

        //Assert
        Assert.Contains(option ,database, Facade<Option>.ToStringAll());
        Assert.AreEqual(3, database.Count, Facade<Option>.ToStringAll());

        //Act
        OptionFacade.Delete(option);
        database = OptionFacade.FindAll();

        //Assert
        Assert.IsFalse(database.Contains(option), Facade<Option>.ToStringAll());
        Assert.IsNotEmpty(database, Facade<Option>.ToStringAll());
    }
}
