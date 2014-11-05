/*
 * ========================================================================
 * Copyright(c) 2013-2014 郑州优创科技有限公司, All Rights Reserved.
 * ========================================================================
 *  
 * 【实体类】
 *  
 *  
 * 作者：唐有炜   时间：2014-11-05 18:10:48
 * 文件名：TFunOperating 
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
	[Table("T_fun_operating")]
	public partial class TFunOperating 
	{
	
		[Id("id",IsDbGenerated=true)]
		public Int32 Id { get;set; }
 
		[Column("comp_num")]
		public String CompNum { get;set; }
		[Column("myapp_id")]
		public Int32 MyappId { get;set; }
		[Column("ope_action")]
		public String OpeAction { get;set; }
		[Column("ope_type")]
		public Int32? OpeType { get;set; }
		[Column("ope_name")]
		public String OpeName { get;set; }
		[Column("ope_icon")]
		public String OpeIcon { get;set; }
		[Column("ope_function")]
		public String OpeFunction { get;set; }
		[Column("ope_is_sys")]
		public Int32 OpeIsSys { get;set; }
		[Column("ope_is_status")]
		public Int32 OpeIsStatus { get;set; }
		[Column("ope_is_fast")]
		public Int32 OpeIsFast { get;set; }
 
		[ManyToOne(ThisKey="MyappId",OtherKey="Id")]
		public TFunMyapp Myapp { get;set; }
 
 
	}
  
}




