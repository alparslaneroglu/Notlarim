﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Notlarim101.Core.DataAccess;
using Notlarim101.DataAccessLayer;
using Notlarim101.DataAccessLayer.Abstract;

namespace Notlarim101.DataAccessLayer.EntityFramework
{
    public class Repository<T>:RepositoryBase,IDataAccess<T> where T : class//T nesnesi referans type olmalidir. Class lar da rt oldugu icin kisit olarak kullanilmistir.
    {
        private DbSet<T> objSet;
        
        public Repository()
        {
            objSet = db.Set<T>();
        }

        public List<T> List()
        {
            return objSet.ToList();
            //DbSet<T>.toList(); db.note.ToList
            //DbSet<Note>.ToList();
            //db.Comment.ToList();
            //db.Category.ToList();
            //db.Liked.ToList()
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return objSet.Where(where).ToList();
        }
        public IQueryable<T> QList(Expression<Func<T, bool>> query)
        {
            return objSet.Where(query);
        }

        public int Insert(T obj)
        {
            objSet.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            objSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> find)
        {
            return objSet.FirstOrDefault(find);
        }

        public int deneme()
        {
            return 5;
        }
    }
}