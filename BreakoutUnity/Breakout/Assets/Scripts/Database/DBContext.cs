using Sqo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Database
{
    static class DBContext
    {
        private static Siaqodb _localDB = null;

        public static Siaqodb LocalDB
        {
            get
            {
                if (_localDB == null)
                    _localDB = new Siaqodb(Application.dataPath, 5);

                return _localDB;
            }
        }
       
    }
}
