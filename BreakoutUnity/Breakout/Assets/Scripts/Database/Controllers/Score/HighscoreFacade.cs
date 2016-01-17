using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Database.Models;
using UnityEngine;

namespace Assets.Scripts.Database.Controllers
{
    public static class HighscoreFacade
    {
        public static List<Highscore> FindAll()
        {
            return DBContext.LocalDB.LoadAll<Highscore>().ToList();
        }

        public static List<Highscore> FindBest10()
        {
            var query = (from Highscore h in DBContext.LocalDB
                        orderby h.Score descending
                        select h).Take(10);

            return query.ToList();
        }

        public static Highscore FindBest()
        {
            var query = (from Highscore h in DBContext.LocalDB
                         orderby h.Score descending
                         select h).Take(1);

            return query.FirstOrDefault();
        }

        public static Highscore FindLast()
        {
            var query = (from Highscore h in DBContext.LocalDB
                         orderby h.Score ascending
                         select h).Take(1);

            return query.FirstOrDefault();
        }

        public static bool Insert(Highscore score)
        {
            List<Highscore> scores = FindBest10();

            if (scores.Count < 10
                || scores[9].Score < score.Score)
            {
                try
                {
                    DBContext.LocalDB.StoreObject(score);
                    DeleteOverBest10();
                }
                catch (Exception ex)
                {
                    return false;
                    throw;
                }
            }
            return true;
        }

        public static bool Insert(string name, int score)
        {
            return Insert(new Highscore() { Name = name, Score = score });
        }
        
        public static void InsertTestHighScore()
        {
            Highscore score = new Highscore() { Name = "Test" + ((int)(UnityEngine.Random.value * 100)).ToString(), Score = (int)(UnityEngine.Random.value * 1000) };
            //Debug.LogFormat("Test Score: {0}", score.ToString());
            HighscoreFacade.Insert(score);
        }

        public static void Delete(Highscore highscore)
        {
            DBContext.LocalDB.Delete(highscore);
        }

        public static void DeleteOverBest10()
        {
            List<Highscore> overflow = FindAll().Except(FindBest10()).ToList();
            //Debug.Log(overflow);

            foreach(Highscore h in overflow)
            {
                Delete(h);
            }
        }

        public static string ToStringAll()
        {
            string highscore = string.Empty;
            List<Highscore> scores = HighscoreFacade.FindAll();
            //Debug.Log(scores.Count);
            scores.Sort();

            for(int i = 0; i < scores.Count; ++i)
            {
                //Debug.LogFormat("{0},{1}", "i=", i);
                highscore += String.Format("{0}.\t{1}\n", i+1, scores[i].ToString());
            }

            return highscore;
        }
    }
}
