using Sqo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    _localDB = new Siaqodb(@".");

                return _localDB;
            }
        }
    }
}
