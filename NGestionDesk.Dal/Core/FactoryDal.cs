using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Dal.Core
{
    public class FactoryDal<T> 
        where T : class
    {
        static T _dals;

        public static T GetDal()
        {
            if (_dals == null) _dals = (T)Activator.CreateInstance(typeof(T));
            return _dals;
        }
    }

    public class FactoryDalWithNumber<T>
        where T : class
    {
        static int _number;
        static T _dals;

        public static T GetDal(int number)
        {
            if (_number != number) 
            {
                _number = number;
                _dals = (T)Activator.CreateInstance(typeof(T), number);
            }
            return _dals;
        }
    }
}
