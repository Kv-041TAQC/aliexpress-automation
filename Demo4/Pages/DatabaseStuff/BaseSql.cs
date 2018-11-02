using System;
using System.Collections.Generic;
using System.Text;

namespace Pages.DatabaseStuff
{
    interface BaseSql<T> where T:class
    {
        void Add(T x);
        void AddRange(T[] arr);
        void Delete(int id);
        List<T> GetAll();
    }
}
