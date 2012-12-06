using System.Collections.Generic;
using System.Linq;

namespace Blog.Core.Database
{
    public interface IDocumentDatabase
    {
        void Insert<T>(T data) where T : class;
        void Save<T>(T data) where T : class;

        void Delete<T>(object value) where T : class;
        void Delete<T>(string column, object value) where T : class;
        void Delete(string collection, string column, object value);
        void Delete(string collection, object value);

        long Count<T>() where T : class;
        IQueryable<T> WithCount<T>(out long count) where T : class;

        IQueryable<T> Query<T>() where T : class;
        IEnumerable<T> All<T>() where T : class;

        void Increment<T>(string value, string incrementColumn, int incrementer);
        void Increment(string collection, string value, string incrementColumn, int incrementer);
    }
}