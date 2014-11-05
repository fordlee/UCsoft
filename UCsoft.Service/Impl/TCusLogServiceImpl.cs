
// ReSharper disable All 禁止ReSharper显示警告
using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using NLite.Data;
using UCsoft.Data;
using UCsoft.Common;
using UCsoft.Entity;
using UCsoft.Dao;
namespace UCsoft.Service.Impl
{
public  class TCusLogServiceImpl: ITCusLogService
    {
	
	#region  依赖注入 2014-11-05 20:23:33 By 唐有炜
	public ITCusLogDao  TCusLogDao{set;get;}
	#endregion

	    #region 逻辑实现 2014-11-05 20:23:33 By 唐有炜

		#region 列表

        /// <summary>
        /// 获取所有数据列表（IEnumerable<Model>） 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="recordCount">总数（用out返回便于后面使用）</param>
        /// <param name="orders">排序字段（字段字典<字段、排序类型>）</param>
        /// <param name="predicate">筛选条件</param>
        public IEnumerable<TCusLog> GetCusLogList()
		{
		  try
            {
                var models = TCusLogDao.GetList();
                LogHelper.Debug("获取CusLog所有数据成功。");
                return models;
            }
            catch (Exception ex)
            {
                LogHelper.Error("获取CusLog所有数据失败。", ex);
                return null;
            }
		}

		 /// <summary>
        /// 获取所有数据列表（IEnumerable<Model>） 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="recordCount">总数（用out返回便于后面使用）</param>
        /// <param name="orders">排序字段（字段字典<字段、排序类型>）</param>
        /// <param name="predicate">筛选条件</param>
        public IEnumerable<TCusLog> GetCusLogList( Expression<Func<TCusLog, bool>> predicate)
		{
		  try
            {
                var models = TCusLogDao.GetList(predicate);
                LogHelper.Debug("获取CusLog所有数据成功。");
                return models;
            }
            catch (Exception ex)
            {
                LogHelper.Error("获取CusLog所有数据失败。", ex);
                return null;
            }
		}


         /// <summary>
        /// 获取信息分页列表（IEnumerable<Model>） 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="recordCount">总数（用out返回便于后面使用）</param>
        /// <param name="orders">排序字段（字段字典<字段、排序类型>）</param>
        /// <param name="predicate">筛选条件</param>
        public IEnumerable<TCusLog> GetCusLogList( int pageIndex, int pageSize, out int recordCount,
            Expression<Func<TCusLog, bool>> predicate,IDictionary<string, UCsoft.Entity.UCEnums.OrderEmum> orders)
        {
            try
            {
                var models = TCusLogDao.GetListByPage(pageIndex, pageSize, out recordCount, orders,
                    predicate);
                LogHelper.Debug("获取CusLog分页列表成功。");
                return models;
            }
            catch (Exception ex)
            {
                recordCount = 0;
                LogHelper.Error("获取CusLog分页列表失败。", ex);
                return null;
            }
        }

		    /// <summary>
        /// 获取信息分页列表（IEnumerable<Model>，动态LINQ） 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="recordCount">总数（用out返回便于后面使用）</param>
        /// <param name="orders">排序字段（字段字典<字段、排序类型>）</param>
        /// <param name="predicate">筛选条件</param>
        public IEnumerable<TCusLog> GetCusLogList( int pageIndex, int pageSize, out int recordCount,
            string predicate,IDictionary<string, UCsoft.Entity.UCEnums.OrderEmum> orders)
        {
            try
            {
                var models = TCusLogDao.GetListByPage(pageIndex, pageSize, out recordCount, orders,
                    predicate);
                LogHelper.Debug("获取CusLog分页列表成功。");
                return models;
            }
            catch (Exception ex)
            {
                recordCount = 0;
                LogHelper.Error("获取CusLog分页列表失败。", ex);
                return null;
            }
        }

        /// <summary>
        /// 获取信息分页列表(DataTable) 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
		/// <param name="selectFields">选择的字段（格式：new string[]{"field1,field2"}，field1如果是主键必须要有）</param>
        /// <param name="strWhere">筛选条件（字段名="值",字段名 in (值1,值2)）</param>
        /// <param name="filedOrder">排序字段（字段名）</param>
        /// <param name="recordCount">总数</param>
        /// <returns>DataTable</returns>
       public DataTable GetCusLogList(string[] selectFields, int pageIndex, int pageSize, out int recordCount,
            string strWhere, string filedOrder)
			{
			try
                {
                    StringBuilder strSql=new StringBuilder();
					//这里添加sql逻辑
                    IDictionary<string, object> namedParameters = new Dictionary<string, object>();
					//这里添加参数
                    var models = TCusLogDao.GetListBySql(strSql.ToString(), namedParameters);
                    recordCount = models.Rows.Count;
                    LogHelper.Debug("获取CusLog分页列表成功。");
                    return models;
                }
                catch (Exception ex)
                {
                    recordCount = 0;
                    LogHelper.Error("获取CusLog分页列表失败。", ex);
                    return null;
                }
			}

			 /// <summary>
        /// 查询分页（可以自定义添加属性，不包括扩展字段） 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="selector">要查询的字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="ordering">排序</param>
        /// <param name="recordCount">记录结果数</param>
        /// <param name="values">参数</param>
        /// <returns>查询分页（包括扩展字段）</returns>
      public  List<Dictionary<string, object>>  GetCusLogList(int pageIndex, int pageSize, string selector,string predicate, string ordering,
            out int recordCount, params object[] values)
			{
		 try
                {
                var models = TCusLogDao.GetListByPage(pageIndex, pageSize, selector, predicate,
                ordering,out recordCount, values);
				   LogHelper.Debug("获取CusLog分页列表成功。");
                return models;
                }
                catch (Exception ex)
                {
                    recordCount = 0;
                    LogHelper.Error("获取CusLog分页列表失败。", ex);
                    return null;
                }
			}

			   /// <summary>
        /// 获取信息分页列表List<Dictionary<string, object>> 2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页的数目</param>
        /// <param name="selector">要查询的字段</param>
        /// <param name="expFields">存储扩展字段值的字段</param>
        /// <param name="expSelector">要查询的扩展字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="ordering">排序</param>
        /// <param name="recordCount">记录结果数</param>
        /// <param name="values">参数</param>
        /// <returns>List<Dictionary<string, object>></returns>
       public List<Dictionary<string, object>> GetCusLogList( string selector, string expFields, string expSelector,int pageIndex, int pageSize, out int recordCount,string predicate, string ordering,params object[] values)
	   {
	  
	   try
                {
                var models = TCusLogDao.GetListWithExpByPage(pageIndex, pageSize, selector, expFields, expSelector, predicate,
                ordering,out recordCount, values);
				   LogHelper.Debug("获取CusLog分页列表成功。");
                return models;
                }
                catch (Exception ex)
                {
                    recordCount = 0;
                    LogHelper.Error("获取CusLog分页列表失败。", ex);
                    return null;
                }
	   }
	   #endregion 


	   #region 查看
	   	  /// <summary>
        /// 获取一条信息  2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>TCusLog</returns>
       public TCusLog GetCusLog(Expression<Func<TCusLog, bool>> predicate)
	   {
	    try
	   	      {
	   	          var model =  TCusLogDao.GetEntity(predicate);
	   	          return model;
	   	      }
	   	      catch (Exception ex)
	   	      {
	   	          LogHelper.Error("获取CusLog失败。", ex);
	   	          return null;
	   	      }
	   }

	    /// <summary>
        /// 根据条件查询某些字段(LINQ 动态查询)
        /// </summary>
        /// <param name="selector">要查询的字段（格式：new(ID,Name)）</param>
        /// <param name="predicate">筛选条件（u=>u.id==0）</param>
        /// <returns></returns>
	public IQueryable<Object> GetFields(string selector, string predicate)
	{
	try
            {
                var fields =  TCusLogDao.GetFields(selector, predicate);
                return fields;
            }
            catch (Exception ex)
            {
                LogHelper.Error("获取字段失败。", ex);
                return null;
            }
	}


	 


        /// <summary>
        /// 获取一条信息(带扩展字段)   2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="selector">要查询的字段</param>
        /// <param name="expFields">存储扩展字段值的字段</param>
        /// <param name="expSelector">要查询的扩展字段里面的字段</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="values">参数</param>
        /// <returns>Dictionary&lt;String, Object&gt;.</returns>
      public  Dictionary<string, object> GetCusLog(string selector, string expFields, string expSelector, string predicate,
            params object[] values){
			 try
                {
			  var model = TCusLogDao.GetEntityWithExp(selector, expFields, expSelector, predicate, values);
			   return model;
			    }
                catch (Exception ex)
                {
                    LogHelper.Error("获取CusLog失败。", ex);
                    return null;
                }
           
			}

      #endregion

	  #region 添加、修改
        /// <summary>
        /// 添加信息  2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="TCusLog">TCusLog</param>
        /// <returns>添加状态</returns>
        public  bool AddCusLog(TCusLog CusLog)
		{
		 var status = false;
		       try
                {
                     status = TCusLogDao.InsertEntity(CusLog);
			    }
                catch (Exception ex)
                {
                    LogHelper.Error("获取CusLog失败。", ex);
                    status = false;
                }

            return status;
           
		
		}

        /// <summary>
        /// 修改信息  2014-11-05 20:23:33 By 唐有炜
        /// </summary>
        /// <param name="id">id</param>
         /// <param name="TCusLog">TCusLog</param>
        /// <returns>添加状态</returns>
        public bool EditCusLog(TCusLog CusLog)
		{
		
		 var status = false;
		       try
                {
                     status = TCusLogDao.UpdateEntity(CusLog);
			    }
                catch (Exception ex)
                {
                    LogHelper.Error("获取CusLog失败。", ex);
                    status = false;
                }

            return status;
           
		}
		#endregion


		#region 改变状态
       

  
   
        /// <summary>
       /// 使用LINQ批量更改TClientInfo状态 2014-09-05 14:58:50 By 唐有炜
       /// </summary>
       /// <param name="fields">要更新的字段（支持批量更新）</param>
       /// <param name="values">The values.</param>
       /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
       public bool UpdateEntityStatus(List<Field> fields, params  object[] values)
			{
            return  TCusLogDao.UpdateEntityStatus(fields, values);
			}
		 #endregion



		 #region  删除信息
		 	/// <summary>
        /// 删除信息 2014-08-30 14:58:50 By 唐有炜
        /// </summary>
        /// <param name="ids">ids</param>
        /// <returns>删除状态</returns>
        public bool DeleteCusLog(string ids)
		{
		       var status = false;
		       try
                {
         	    var idArray = Utils.StringToObjectArray(ids, ',');
                List<string> predicates = new List<string>();
                foreach (var idArr in idArray)
                {
                    string predicate = String.Concat(new[] {"Id =", idArr});
                    predicates.Add(predicate);
                }

                status = TCusLogDao.DeletesEntity(predicates);
				}
                catch (Exception ex)
                {
                    LogHelper.Error("获取CusLog失败。", ex);
                    status = false;
                }

            return status;
           
		
		}
		#endregion

        #endregion


      

		#region 验证   2014-11-05 20:23:33 By 唐有炜

        /// <summary>
        /// 验证字段是否存在  2014-10-15 16:58:59 By 唐有炜
        /// </summary>
        /// <param name="fields">字段集合</param>
        /// <returns>验证状态</returns>
        public bool Validate(string predicate, params object[] values)
        {
            var status = TCusLogDao.ExistsEntity(predicate,values);
            return status;
        }

        #endregion
	}
}
