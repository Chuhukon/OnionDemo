using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using OnionDemo.Core.Base;
using OnionDemo.Core.Model;

namespace Onion.Infrastructure
{
    public class AlbumRepository : IAlbumRepository
    {
        Context context = new Context();

        public IQueryable<Album> All
        {
            get { return context.Albums; }
        }

        public IQueryable<Album> AllIncluding(params Expression<Func<Album, object>>[] includeProperties)
        {
            IQueryable<Album> query = context.Albums;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Album Find(int id)
        {
            return context.Albums.Find(id);
        }

        public void InsertOrUpdate(Album album)
        {
            if (album.ID == default(int))
            {
                // New entity
                context.Albums.Add(album);
            }
            else
            {
                // Existing entity
                context.Entry(album).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var album = context.Albums.Find(id);
            context.Albums.Remove(album);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
