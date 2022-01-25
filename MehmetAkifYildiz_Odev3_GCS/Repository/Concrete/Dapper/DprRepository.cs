using Dapper;
using Dommel;
using GCS.Domain.Abstract;
using GCS.Repository.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.Dapper
{
    public class DprRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected IDbConnection _connection;
        public DprRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Add(TEntity entity)
        {
            _connection.Open();
            _connection.Insert(entity);

        }

        public void Delete(TEntity entity)
        {

            _connection.Open();
            _connection.Delete(entity);
            
        }

        public void DeleteAll(IEnumerable<TEntity> entities)
        {
            _connection.Open();
            foreach (var entity in entities)
            {
                _connection.Delete(entity);
            }              
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
                return _connection.FirstOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? _connection.GetAll<TEntity>()
                : _connection.Select(filter);
        }

        public void Update(TEntity entity)
        {
            _connection.Open();
            _connection.Update(entity);
        }
    }
}
