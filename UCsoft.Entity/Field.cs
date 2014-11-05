// ***********************************************************************
// Assembly         : UCsoft.Entity
// Author           : tangyouwei
// Created          : 10-24-2014
//
// Last Modified By : tangyouwei
// Last Modified On : 10-24-2014
// ReSharper disable All 禁止ReSharper显示警告
// ***********************************************************************
// <copyright file="Field.cs" company="郑州优创软件科技有限公司">
//     Copyright (c) www.ucs123.com. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// The Entity namespace.
/// </summary>

namespace UCsoft.Entity
{
    /// <summary>
    /// 自定义字段封装类 14-10-24 By 唐有炜
    /// </summary>
    public class Field
    {
        /// <summary>
        ///字段唯一标识 14-10-24 By 唐有炜
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { set; get; }

        /// <summary>
        ///字段的key 14-10-24 By 唐有炜
        /// </summary>
        /// <value>The key.</value>
        public string Key { set; get; }

        /// <summary>
        ///字段的值 14-10-24 By 唐有炜
        /// </summary>
        /// <value>The value.</value>
        public object Value { set; get; }

        /// <summary>
        /// 更新条件 14-10-24 By 唐有炜
        /// </summary>
        /// <value>The predicate.</value>
        public string Predicate { set; get; }
        /// <summary>
        /// 参数   14-10-24 By 唐有炜
        /// </summary>
        /// <value>The values.</value>
        public  object[] Parms { set; get; }
    }
}