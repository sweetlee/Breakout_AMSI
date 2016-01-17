﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Database.Models;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Database.Controllers
{
    public static class HighscoreFacade
    {
        public static List<Highscore> FindAll()
        {
            return DBContext.LocalDB.LoadAll<Highscore>().ToList();
        }

        public static bool Insert(Highscore score)
        {
            try
            {
                DBContext.LocalDB.StoreObject(score);
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return true;
        }

        public static bool Insert(string name, int score)
        {
            return Insert(new Highscore() { Name = name, Score = score });
        }

        public static string ToStringAll()
        {
            string highscore = string.Empty;
            List<Highscore> scores = HighscoreFacade.FindAll();
            Debug.Log(scores.Count);
            scores.Sort();

            for(int i = 0; i < scores.Count; ++i)
            {
                Debug.LogFormat("{0},{1}", "i=", i);
                highscore += String.Format("{0}.\t{1}\n", i+1, scores[i].ToString());
            }

            return highscore;
        }
    }
}