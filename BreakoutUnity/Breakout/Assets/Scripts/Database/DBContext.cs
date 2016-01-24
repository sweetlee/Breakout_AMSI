using Sqo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Database
{
    public static class DBContext
    {
        private static Siaqodb _localDB = null;
        public static Siaqodb LocalDB
        {
            get
            {
                if (_localDB == null){
					_localDB = new Siaqodb(Application.dataPath, 1048576);
				}

                return _localDB;
            }
        }
       
        public static void Delete()
        {
            string db = Application.dataPath + "data.mdb";
            if(File.Exists(db))
            {
                File.Delete(db);
            }
        }
    }
}
