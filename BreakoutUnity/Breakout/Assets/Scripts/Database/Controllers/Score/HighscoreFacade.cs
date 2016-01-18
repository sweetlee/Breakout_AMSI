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
            List<Highscore> list = Facade<Highscore>.FindAll();
            list.Sort();

            return list;
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

        public static bool Save(Highscore score)
        {
            List<Highscore> scores = FindBest10();

            if (scores.Count < 10
                || scores[9].Score < score.Score)
            {
                bool result = Facade<Highscore>.Save(score);
                //Debug.Log(result.ToString());
                if (result) DeleteOverBest10();

                return result;
            }
            return true;
        }

        public static bool Save(string name, int score)
        {
            return Save(new Highscore() { Name = name, Score = score });
        }
        
        public static void InsertTestHighScore()
        {
            Highscore score = new Highscore() { Name = "Test" + ((int)(UnityEngine.Random.value * 100)).ToString(), Score = (int)(UnityEngine.Random.value * 1000) };
            Debug.LogFormat("Test Score: {0}", score.ToString());
            HighscoreFacade.Save(score);
        }

        public static void Delete(Highscore highscore)
        {
            Facade<Highscore>.Delete(highscore);
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
    }
}
