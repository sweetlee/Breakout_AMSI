using Assets.Scripts.Database.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Database.Models
{
    public partial class Highscore : IComparable, IEquatable<Highscore>
    {
        public int CompareTo(object obj)
        {
            Highscore c = (Highscore)obj;
            return c.Score.CompareTo(Score);
        }

        public bool Equals(Highscore other)
        {
            if (other == null)
                return false;

            return Score.Equals(other.Score) && Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}", Name, Score);
        }
    }
}
