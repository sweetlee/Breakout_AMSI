using Assets.Scripts.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Models
{
    public partial class Highscore : IComparable
    {
        public int CompareTo(object obj)
        {
            Highscore c = (Highscore)obj;
            return c.Score.CompareTo(Score);
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}", Name, Score);
        }
    }
}
