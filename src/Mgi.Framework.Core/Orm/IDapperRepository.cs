using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Mgi.Framework.Core;
using MicroOrm.Dapper.Repositories.SqlGenerator;

namespace MicroOrm.Dapper.Repositories
{
    /// <summary>
    ///     interface for repository
    /// </summary>
    public interface IDapperRepository<TEntity, PK> where TEntity : class
    {
        /// <summary>
        ///     SQL Genetator
        /// </summary>
        ISqlGenerator<TEntity> SqlGenerator { get; }

        /// <summary>
        ///     Get number of rows
        /// </summary>
        int Count();

        /// <summary>
        ///     Get number of rows
        /// </summary>
        int Count(IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with WHERE clause
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get number of rows with WHERE clause
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with DISTINCT clause
        /// </summary>
        int Count(Expression<Func<TEntity, object>> distinctField);

        /// <summary>
        ///     Get number of rows with DISTINCT clause
        /// </summary>
        int Count(Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with DISTINCT and WHERE clause
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField);

        /// <summary>
        ///     Get number of rows with DISTINCT and WHERE clause
        /// </summary>
        int Count(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        ///     Get number of rows
        /// </summary>
        Task<int> CountAsync(IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with WHERE clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get number of rows with WHERE clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with DISTINCT clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, object>> distinctField);

        /// <summary>
        ///     Get number of rows with DISTINCT clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction);

        /// <summary>
        ///     Get number of rows with DISTINCT and WHERE clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField);

        /// <summary>
        ///     Get number of rows with DISTINCT and WHERE clause
        /// </summary>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> distinctField, IDbTransaction transaction);

        /// <summary>
        ///     Get first object
        /// </summary>
        TEntity SingleOrDefault();

        /// <summary>
        ///     Get first object
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get first object
        /// </summary>
        TEntity SingleOrDefault(IDbTransaction transaction);

        /// <summary>
        ///     Get first object
        /// </summary>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1, TChild2, TChild3, TChild4>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1, TChild2, TChild3, TChild4, TChild5>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        TEntity SingleOrDefault<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id
        /// </summary>
        TEntity FindById(object id);

        /// <summary>
        ///     Get object by Id
        /// </summary>
        TEntity FindById(object id, IDbTransaction transaction);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1>(object id,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1, TChild2>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1, TChild2, TChild3>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1, TChild2, TChild3, TChild4>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1, TChild2, TChild3, TChild4, TChild5>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        TEntity FindById<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id
        /// </summary>
        Task<TEntity> FindByIdAsync(object id);

        /// <summary>
        ///     Get object by Id
        /// </summary>
        Task<TEntity> FindByIdAsync(object id, IDbTransaction transaction);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1>(object id,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1, TChild2>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1, TChild2, TChild3>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1, TChild2, TChild3, TChild4>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1, TChild2, TChild3, TChild4, TChild5>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get object by Id with join objects
        /// </summary>
        Task<TEntity> FindByIdAsync<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(object id,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync();

        /// <summary>
        ///     Get first object
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync(IDbTransaction transaction);

        /// <summary>
        ///     Get first object
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get first object
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1, TChild2>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1, TChild2, TChild3>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1, TChild2, TChild3, TChild4>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1, TChild2, TChild3, TChild4, TChild5>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get first object with join objects
        /// </summary>
        Task<TEntity> SingleOrDefaultAsync<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects
        /// </summary>
        IEnumerable<TEntity> Find(IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects
        /// </summary>
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> tChild1, IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        IEnumerable<TEntity> Find<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync(IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1, TChild2>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1, TChild2, TChild3>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1, TChild2, TChild3, TChild4>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1, TChild2, TChild3, TChild4, TChild5>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Get all objects with join objects
        /// </summary>
        Task<IEnumerable<TEntity>> FindAsync<TChild1, TChild2, TChild3, TChild4, TChild5, TChild6>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> tChild1,
            Expression<Func<TEntity, object>> tChild2,
            Expression<Func<TEntity, object>> tChild3,
            Expression<Func<TEntity, object>> tChild4,
            Expression<Func<TEntity, object>> tChild5,
            Expression<Func<TEntity, object>> tChild6,
            IDbTransaction transaction = null);

        /// <summary>
        ///     Insert object to DB
        /// </summary>
        bool Insert(TEntity instance);

        /// <summary>
        ///     Insert object to DB
        /// </summary>
        bool Insert(TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Insert object to DB
        /// </summary>
        Task<bool> InsertAsync(TEntity instance);

        /// <summary>
        ///     Insert object to DB
        /// </summary>
        Task<bool> InsertAsync(TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Bulk Insert objects to DB
        /// </summary>
        int BulkInsert(IEnumerable<TEntity> instances, IDbTransaction transaction = null);

        /// <summary>
        ///     Bulk Insert objects to DB
        /// </summary>
        Task<int> BulkInsertAsync(IEnumerable<TEntity> instances, IDbTransaction transaction = null);

        PK InsertGetId(TEntity instance);
        PK InsertGetId(TEntity instance, IDbTransaction transaction);

        Task<PK> InsertGetIdAsync(TEntity instance);
        Task<PK> InsertGetIdAsync(TEntity instance, IDbTransaction transaction);
        int DeleteById(PK id, IDbTransaction transaction = null);
        Task<int> DeleteByIdAsync(PK id, IDbTransaction transaction = null);

        /// <summary>
        ///     Delete object from DB
        /// </summary>
        int Delete(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///     Delete object from DB
        /// </summary>
        Task<int> DeleteAsync(TEntity instance, IDbTransaction transaction = null);

        /// <summary>
        ///     Delete objects from DB
        /// </summary>
        int Delete(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///     Delete objects from DB
        /// </summary>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate, IDbTransaction transaction = null);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        int Update(TEntity instance);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        int Update(TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        Task<int> UpdateAsync(TEntity instance);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        Task<int> UpdateAsync(TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        int Update(Expression<Func<TEntity, bool>> predicate, TEntity instance);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        int Update(Expression<Func<TEntity, bool>> predicate, TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity instance);

        /// <summary>
        ///     Update object in DB
        /// </summary>
        Task<int> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity instance, IDbTransaction transaction);

        /// <summary>
        ///     Bulk Update objects in DB
        /// </summary>
        Task<int> BulkUpdateAsync(IEnumerable<TEntity> instances);

        /// <summary>
        ///     Bulk Update objects in DB
        /// </summary>
        Task<int> BulkUpdateAsync(IEnumerable<TEntity> instances, IDbTransaction transaction);

        /// <summary>
        ///     Bulk Update objects in DB
        /// </summary>
        int BulkUpdate(IEnumerable<TEntity> instances);

        /// <summary>
        ///     Bulk Update objects in DB
        /// </summary>
        int BulkUpdate(IEnumerable<TEntity> instances, IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(object from, object to, Expression<Func<TEntity, object>> btwField);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        IEnumerable<TEntity> FindBetween(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(object from, object to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            object from,
            object to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(DateTime from, DateTime to, Expression<Func<TEntity, object>> btwField, IDbTransaction transaction);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get all objects with BETWEEN query
        /// </summary>
        Task<IEnumerable<TEntity>> FindAllBetweenAsync(
            DateTime from,
            DateTime to,
            Expression<Func<TEntity, object>> btwField,
            Expression<Func<TEntity, bool>> predicate,
            IDbTransaction transaction);

        PageResult<TEntity> Search(SearchArgs<TEntity> searchArgs, IDbTransaction transaction = null);

        Task<PageResult<TEntity>> SearchAsync(SearchArgs<TEntity> searchArgs, IDbTransaction transaction = null);
    }
}
