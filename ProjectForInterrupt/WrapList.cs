using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForInterrupt
{
    internal class WrapList<T>
    {
        private List<string> _list;
        private readonly object _lock; 


        public WrapList()
        {
            _list = new List<string>();
            _lock = new object();
        }

        public void Add(string value)
        {
            lock(_lock)
            {
                for (int i = 0; i < 10; i++)
                {
                    _list.Add(value + ' ' + i + " from thread");
                }
                Thread.Sleep(5);
            }
        }


        public List<string> Get()
        {
            lock(_lock)
            {
                return _list;
            }
        }
    }
}
