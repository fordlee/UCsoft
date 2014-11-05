using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using UCsoft.Entity;

namespace UCsoft.Dao
{
    /// <summary>
    /// Dao层Table接口 2014-08-28 04:10:51 By 唐有炜
    /// </summary>
    public interface ITableDao<T>
    {
        #region 读操作

        #region  获取数据总数

        /// <summary>
        /// 获取数据总数（默认）
        /// </summary>
        /// <returns>返回所有数据总数</returns>
        int GetCount();

        /// <summary>
        /// 获取数据总数（LINQ）
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据总数</returns>
        int GetCount(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取数据总数（动态LINQ）
        /// </summary>
        /// <param name="predicate">动态LINQ</param>
        /// <param name="values">参数</param>
        /// <returns>返回所有数据总数</returns>
        int GetCount(string predicate, params object[] values);

        #endregion

        #region  获取最大Id

        /// <summary>
        /// 获取最大Id（默认）
        /// </summary>
        /// <returns></returns>
        int GetMaxId();

        /// <summary>
        /// 获取最大Id（LINQ）
        /// </summary>
        /// <returns></returns>
        //int GetMaxId(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 获取最大Id（动态LINQ）
        /// </summary>
        /// <returns></returns>
        //int GetMaxId(string predicate, params object[] values);

        #endregion

        #region 获取所有的数据

        /// <summary>
        /// 获取所有的数据（默认）
        /// </summary>
        /// <returns>返回所有数据列表</returns>
        List<T> GetList();


        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>返回所有数据列表</returns>
        List<T> GetList(Expression<Func<T, bool>> predicate);


//        /// <summary>
//        /// 获取所有数据（）
//        /// </summary>
//        /// <returns></returns>
//        List<Dictionary<string, object>> GetDictionaryList();
//


//
//
//        /// <summary>
//        /// 获取所有数据（可动态追加字段）
//        /// </summary>
//        /// <returns></returns>
//        List<Dictionary<string, object>> GetDictionaryList(string predicate);

        #endregion

        #region 查询分页

        //查询分页
        /// <summary>
        /// 查询分页 2014-09-12 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页得得数目</param>
        /// <param name="rowCount">总数</param>
        /// <param name="orders">排序字段，可以有多个</param>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        IPagination<T> GetListByPage(int pageIndex, int pageSize, out int rowCount,
            IDictionary<string, UCEnums.OrderEmum> orders,
            Expression<Func<T, bool>> predicate);

        //查询分页（动态LINQ）
        /// <summary>
        /// 查询分页（动态LINQ） 2014-09-12 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页得得数目</param>
        /// <param name="rowCount">总数</param>
        /// <param name="orders">The orders.</param>
        /// <param name="predicate">查询条件</param>
        /// <returns>IPagination&lt;T&gt;.</returns>
        IPagination<T> GetListByPage(int pageIndex, int pageSize, out int rowCount,
            IDictionary<string, UCEnums.OrderEmum> orders,
            string predicate);

        /// <summary>
        /// 查询分页（可以自定义添加属性，不包括扩展字段） 2014-10-15 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="selector">要查询的字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="ordering">排序</param>
        /// <param name="recordCount">记录结果数</param>
        /// <param name="values">参数</param>
        /// <returns>查询分页（包括扩展字段）</returns>
        List<Dictionary<string, object>> GetListByPage(int pageIndex, int pageSize, string selector, string predicate,
            string ordering, out int recordCount, params object[] values);

        /// <summary>
        /// 查询分页（包括扩展字段） 2014-08-29 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="selector">要查询的字段</param>
        /// <param name="expFields">存储扩展字段值的字段</param>
        /// <param name="expSelector">要查询的扩展字段里面的字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="ordering">排序</param>
        /// <param name="recordCount">记录结果数</param>
        /// <param name="values">参数</param>
        /// <returns>查询分页（包括扩展字段）</returns>
        List<Dictionary<string, object>> GetListWithExpByPage(int pageIndex, int pageSize, string selector,
            string expFields, string expSelector,
            string predicate, string ordering,
            out int recordCount, params object[] values);

        #endregion

        #region  获取指定的单个实体

        /// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        T GetEntity(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// 返回单个实体（带扩展字段）
        /// </summary>
        /// <param name="selector">要查询的字段</param>
        /// <param name="expFields">存储扩展字段值的字段</param>
        /// <param name="expSelector">要查询的扩展字段里面的字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="values">参数</param>
        /// <returns>Dictionary&lt;String, Object&gt;.</returns>
        Dictionary<string, object> GetEntityWithExp(string selector, string expFields, string expSelector,
            string predicate,
            params object[] values);

        #endregion

        #region 根据条件查询某些字段(LINQ 动态查询)

        /// <summary>
        /// 根据条件查询某些字段(LINQ 动态查询)
        /// </summary>
        /// <param name="selector">要查询的字段（格式：new(ID,Name)）</param>
        /// <param name="predicate">筛选条件（id==1）</param>
        /// <returns></returns>
        IQueryable<Object> GetFields(string selector, string predicate, params object[] values);

        #endregion

     

        #region 是否存在该记录

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <returns></returns>
        bool ExistsEntity(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 是否存在该记录(动态LINQ)
        /// </summary>
        /// <returns></returns>
        bool ExistsEntity(string predicate, params object[] values);

        #endregion

        #region 原生Sql方法

        //以下是原生Sql方法==============================================================
        //===========================================================================
        /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="namedParameters">sql参数</param>
        /// <returns>集合</returns>
        DataTable GetListBySql(string sql, dynamic namedParameters = null);

        #endregion

        #endregion

        #region 写操作


        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        bool InsertEntity(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="predicate">动态LINQ</param>
        bool DeleteEntity(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// 批量删除（实体集合）
        /// </summary>
        /// <param name="predicates">条件集合</param>
        /// <returns></returns>
        bool DeletesEntity(List<string> predicates);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        bool UpdateEntity(T entity);


        //
        //        /// <summary>
        //        /// 使用LINQ批量更改T状态 2014-09-05 14:58:50 By 唐有炜
        //        /// </summary>
        //        /// <param name="fields">要更新的字段（支持批量更新）</param>
        //        /// <param name="predicate">条件</param>
        //        /// <returns></returns>
        //        bool UpdateEntityStatus(Dictionary<string, object> fields,
        //          string predicate, params  object[] values);

        /// <summary>
        /// 使用LINQ批量更改TClientInfo状态 2014-09-05 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="fields">要更新的字段（支持批量更新）</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool UpdateEntityStatus(List<Field> fields, params object[] values);
        /// <summary>
        /// 执行Sql
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="namedParameters">查询字符串</param>
        /// <returns></returns>
        bool ExecuteSql(string sql, dynamic namedParameters = null);

        #endregion
    }
}