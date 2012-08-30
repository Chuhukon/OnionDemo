using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Core.Model;

namespace OnionDemo.Core.Base
{
    public interface IAlbumRepository : IDisposable
    {
        IQueryable<Album> All { get; }
        IQueryable<Album> AllIncluding(params Expression<Func<Album, object>>[] includeProperties);
        Album Find(int id);
        void InsertOrUpdate(Album album);
        void Delete(int id);
        void Save();
    }
}
