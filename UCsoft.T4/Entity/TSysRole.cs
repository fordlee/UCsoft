/*
 * ========================================================================
 * Copyright(c) 2013-2014 郑州优创科技有限公司, All Rights Reserved.
 * ========================================================================
 *  
 * 【实体类】
 *  
 *  
 * 作者：唐有炜   时间：2014-11-05 18:10:48
 * 文件名：TSysRole 
 * 版本：V1.0.0
 * 
 * 修改者：唐有炜           时间：2014-11-05 18:10:48            
 * 修改说明：修改说明
 * ========================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using NLite.Data;
namespace UCsoft.Entity
{
	[Table("T_sys_role")]
	public partial class TSysRole 
	{
	
		[Id("id",IsDbGenerated=true)]
		public Int32 Id { get;set; }
 
		[Column("comp_num")]
		public String CompNum { get;set; }
		[Column("role_name")]
		public String RoleName { get;set; }
		[Column("role_type")]
		public Int32 RoleType { get;set; }
		[Column("role_issys")]
		public Int32 RoleIssys { get;set; }
		[Column("role_order")]
		public Int32? RoleOrder { get;set; }
		[Column("role_desc")]
		public String RoleDesc { get;set; }
 
 
 
	}
  
}




