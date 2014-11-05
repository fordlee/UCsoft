
/*
 * ========================================================================
 * Copyright(c) 2013-2014 郑州优创科技有限公司, All Rights Reserved.
 * ========================================================================
 *  
 * 【Ed数据库操作上下文】
 *  
 *  
 * 作者：唐有炜   时间：2014-11-05 16:29:42
 * 文件名：@dbContextName
 * 版本：V1.0.0
 * 
 * 修改者：唐有炜           时间：2014-11-05 16:29:42            
 * 修改说明：修改说明
 * ========================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using NLite.Data;
using UCsoft.Entity;
using NLite.Reflection;
namespace UCsoft.Data
{
	public partial class DBContext:DbContext
	{
	    #region 初始化上下文
		//连接字符串名称：基于Config文件中连接字符串的配置
        const string connectionStringName = "SqlServer";

        //构造dbConfiguration 对象
        static DbConfiguration dbConfiguration;

		static DBContext()
		{
			 dbConfiguration = DbConfiguration
                  .Configure(connectionStringName)
                  .SetSqlLogger(() =>SqlLog.Debug)
				  .AddFromAssemblyOf<DBContext>(t=>t.HasAttribute<TableAttribute>(false))
				  ;
		}

		public DBContext():base(dbConfiguration){}
		#endregion

		#region 数据集关联
		public IDbSet<TCusBase> TCusBases { get; private set; }
		public IDbSet<TCusCon> TCusCons { get; private set; }
		public IDbSet<TCusLog> TCusLogs { get; private set; }
		public IDbSet<TFunApp> TFunApps { get; private set; }
		public IDbSet<TFunAppCompany> TFunAppCompanies { get; private set; }
		public IDbSet<TFunExpand> TFunExpands { get; private set; }
		public IDbSet<TFunFilter> TFunFilters { get; private set; }
		public IDbSet<TFunMyapp> TFunMyapps { get; private set; }
		public IDbSet<TFunMyappCompany> TFunMyappCompanies { get; private set; }
		public IDbSet<TFunOperating> TFunOperatings { get; private set; }
		public IDbSet<TFunTag> TFunTags { get; private set; }
		public IDbSet<TSysCompany> TSysCompanies { get; private set; }
		public IDbSet<TSysDepartment> TSysDepartments { get; private set; }
		public IDbSet<TSysLog> TSysLogs { get; private set; }
		public IDbSet<TSysPower> TSysPowers { get; private set; }
		public IDbSet<TSysRole> TSysRoles { get; private set; }
		public IDbSet<TSysUser> TSysUsers { get; private set; }
		public IDbSet<VAppCompany> VAppCompanies { get; private set; }
		public IDbSet<VCompanyUser> VCompanyUsers { get; private set; }
		public IDbSet<VCustomerContact> VCustomerContacts { get; private set; }
		public IDbSet<VMyappCompany> VMyappCompanies { get; private set; }
		public IDbSet<VSysDepartment> VSysDepartments { get; private set; }
        #endregion
	}
	}
	