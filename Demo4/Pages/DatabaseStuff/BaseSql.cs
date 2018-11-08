using System.Collections;

namespace Pages.DatabaseStuff
{
    interface BaseSql<T> where T:class
    {
        void Add(T x);
        void AddRange(T[] arr);
        void Delete(int id,string table);
        ArrayList GetAll(string tablename);
        ArrayList GetOne(int id, string tablename);
    }
}
