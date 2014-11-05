// ***********************************************************************
// Assembly         : UCsoft.Common
// Author           : Tangyouwei
// Created          : 2014-10-14 21:34:34
//
// Last Modified By : Tangyouwei
// Last Modified On : 2014-10-11 04:53:32
// ***********************************************************************
// <copyright file="Utils.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
//ReSharper disable All 禁止ReSharper显示警告

using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using UCsoft.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// The Common namespace.
/// </summary>

namespace UCsoft.Common
{
    /// <summary>
    /// Class Utils.
    /// 2014-10-11 04:53:32 修改 By 唐有炜
    /// </summary>
    public class Utils
    {

        #region 系统版本

        /// <summary>
        /// 版本信息类
        /// </summary>
        public class VersionInfo
        {
            public int FileMajorPart
            {
                get { return 2; }
            }

            public int FileMinorPart
            {
                get { return 1; }
            }

            public int FileBuildPart
            {
                get { return 0; }
            }

            public string ProductName
            {
                get { return "UCsoft"; }
            }

            public int ProductType
            {
                get { return 0; }
            }
        }

        public static string GetVersion()
        {
            return UCKeys.ASSEMBLY_VERSION;
        }

        #endregion

        #region 将字符串分割成对象数组  14-10-18 By 唐有炜

        /// <summary>
        /// 将字符串分割成对象数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split">分割符</param>
        /// <returns>System.Object[].</returns>
        public static object[] StringToObjectArray(string str, char split)
        {
            var strs = new object[] {};
            try
            {
                strs = str.Split(split);
            }
            catch
            {
                return strs;
            }

            return strs;
        }

        #endregion

        #region 将字符串分割成Dictionary  14-10-18 By 唐有炜

        /// <summary>
        /// 将字符串分割成Dictionary
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="split1">分隔符1</param>
        /// <param name="split2">分隔符2</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        public static Dictionary<string, object> StringToObjectDictionary(string str, char split1, char split2)
        {
            string[] array = str.Split(split1);
            string[] temp = null;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            foreach (var s in array)
            {
                temp = s.Split(split2);
                dictionary.Add(temp[0], temp[1]);
            }

            return dictionary;
        }

        #endregion

        #region 对象转换处理

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object expression)
        {
            if (expression != null)
                return IsNumeric(expression.ToString());

            return false;
        }

        /// <summary>
        /// 判断对象是否为Int32类型的数字
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string str = expression;
                if (str.Length > 0 && str.Length <= 11 && Regex.IsMatch(str, @"^[-]?[0-9]*[.]?[0-9]*$"))
                {
                    if ((str.Length < 10) || (str.Length == 10 && str[0] == '1') ||
                        (str.Length == 11 && str[0] == '-' && str[1] == '1'))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为Double类型
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(object expression)
        {
            if (expression != null)
                return Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$");

            return false;
        }

        /// <summary>
        /// 将字符串转换为数组
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[',']);
        }

        /// <summary>
        /// 将数组转换为字符串
        /// </summary>
        /// <param name="list">List</param>
        /// <param name="speater">分隔符</param>
        /// <returns>String</returns>
        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append(list[i]);
                }
                else
                {
                    sb.Append(list[i]);
                    sb.Append(speater);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// object型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
                return StrToBool(expression, defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为bool型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的bool类型结果</returns>
        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (String.Compare(expression, "true", true) == 0)
                    return true;
                else if (String.Compare(expression, "false", true) == 0)
                    return false;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// 将字符串转换为Int32类型
        /// </summary>
        /// <param name="expression">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string expression, int defValue)
        {
            if (String.IsNullOrEmpty(expression) || expression.Trim().Length >= 11 ||
                !Regex.IsMatch(expression.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(expression, out rv))
                return rv;

            return Convert.ToInt32(StrToFloat(expression, defValue));
        }

        /// <summary>
        /// Object型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal ObjToDecimal(object expression, decimal defValue)
        {
            if (expression != null)
                return StrToDecimal(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为decimal型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的decimal类型结果</returns>
        public static decimal StrToDecimal(string expression, decimal defValue)
        {
            if ((expression == null) || (expression.Length > 10))
                return defValue;

            decimal intValue = defValue;
            if (expression != null)
            {
                bool IsDecimal = Regex.IsMatch(expression, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsDecimal)
                    Decimal.TryParse(expression, out intValue);
            }
            return intValue;
        }

        /// <summary>
        /// Object型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjToFloat(object expression, float defValue)
        {
            if (expression != null)
                return StrToFloat(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string expression, float defValue)
        {
            if ((expression == null) || (expression.Length > 10))
                return defValue;

            float intValue = defValue;
            if (expression != null)
            {
                bool IsFloat = Regex.IsMatch(expression, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                    Single.TryParse(expression, out intValue);
            }
            return intValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            if (!String.IsNullOrEmpty(str))
            {
                DateTime dateTime;
                if (DateTime.TryParse(str, out dateTime))
                    return dateTime;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj)
        {
            return StrToDateTime(obj.ToString());
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StrToDateTime(obj.ToString(), defValue);
        }

        /// <summary>
        /// 将对象转换为字符串
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的string类型结果</returns>
        public static string ObjectToStr(object obj)
        {
            if (obj == null)
                return "";
            return obj.ToString().Trim();
        }

        #endregion


        #region URL处理

        /// <summary>
        /// URL字符编码
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string UrlEncode(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            str = str.Replace("'", "");
            return HttpContext.Current.Server.UrlEncode(str);
        }

        /// <summary>
        /// URL字符解码
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string UrlDecode(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }

        #endregion


        #region 检测是否有Sql危险字符

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 检查危险字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Filter(string sInput)
        {
            if (sInput == null || sInput == "")
                return null;
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = @"*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.Compiled | RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("字符串中含有非法字符!");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }

        /// <summary> 
        /// 检查过滤设定的危险字符
        /// </summary> 
        /// <param name="InText">要过滤的字符串 </param> 
        /// <returns>如果参数存在不安全字符，则返回true </returns> 
        public static bool SqlFilter(string word, string InText)
        {
            if (InText == null)
                return false;
            foreach (string i in word.Split('|'))
            {
                if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 过滤特殊字符

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string Htmls(string Input)
        {
            if (Input != String.Empty && Input != null)
            {
                string ihtml = Input.ToLower();
                ihtml = ihtml.Replace("<script", "&lt;script");
                ihtml = ihtml.Replace("script>", "script&gt;");
                ihtml = ihtml.Replace("<%", "&lt;%");
                ihtml = ihtml.Replace("%>", "%&gt;");
                ihtml = ihtml.Replace("<$", "&lt;$");
                ihtml = ihtml.Replace("$>", "$&gt;");
                return ihtml;
            }
            else
            {
                return String.Empty;
            }
        }

        #endregion


        #region 检查是否为IP地址

        /// <summary>
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        #endregion

        #region 获得配置文件节点XML文件的绝对路径

        public static string GetXmlMapPath(string xmlName)
        {
            string pathname = ConfigurationManager.AppSettings[xmlName].ToString();
            string path=GetMapPath(pathname);
            return path;
        }

        #endregion

        #region 获得当前绝对路径

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序
            {
                  return "";
            }
        }

        #endregion

        #region 文件操作

        /// <summary>
        /// 删除单个文件
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        public static bool DeleteFile(string _filepath)
        {
            if (String.IsNullOrEmpty(_filepath))
            {
                return false;
            }
            string fullpath = GetMapPath(_filepath);
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <returns></returns>
        public static bool Deletezifile(string str)
        {
            DirectoryInfo di = new DirectoryInfo(str);
            FileInfo[] f = di.GetFiles(); //文件夹下所有文件
            foreach (FileInfo myFile in f)
            {
                myFile.Delete(); //删除这个文件就可以了
            }
            return true;
        }

        /// <summary>
        /// 删除上传的文件(及缩略图)
        /// </summary>
        /// <param name="_filepath"></param>
        public static void DeleteUpFile(string _filepath)
        {
            if (String.IsNullOrEmpty(_filepath))
            {
                return;
            }
            string fullpath = GetMapPath(_filepath); //原图
            if (File.Exists(fullpath))
            {
                File.Delete(fullpath);
            }
            if (_filepath.LastIndexOf("/") >= 0)
            {
                string thumbnailpath = _filepath.Substring(0, _filepath.LastIndexOf("/")) + "mall_" +
                                       _filepath.Substring(_filepath.LastIndexOf("/") + 1);
                string fullTPATH = GetMapPath(thumbnailpath); //宿略图
                if (File.Exists(fullTPATH))
                {
                    File.Delete(fullTPATH);
                }
            }
        }

        /// <summary>
        /// 返回文件大小KB
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns>int</returns>
        public static int GetFileSize(string _filepath)
        {
            if (String.IsNullOrEmpty(_filepath))
            {
                return 0;
            }
            string fullpath = GetMapPath(_filepath);
            if (File.Exists(fullpath))
            {
                FileInfo fileInfo = new FileInfo(fullpath);
                return ((int)fileInfo.Length) / 1024;
            }
            return 0;
        }

        /// <summary>
        /// 返回文件扩展名，不含“.”
        /// </summary>
        /// <param name="_filepath">文件全名称</param>
        /// <returns>string</returns>
        public static string GetFileExt(string _filepath)
        {
            if (String.IsNullOrEmpty(_filepath))
            {
                return "";
            }
            if (_filepath.LastIndexOf(".") > 0)
            {
                return _filepath.Substring(_filepath.LastIndexOf(".") + 1); //文件扩展名，不含“.”
            }
            return "";
        }

        /// <summary>
        /// 返回文件名，不含路径
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns>string</returns>
        public static string GetFileName(string _filepath)
        {
            return _filepath.Substring(_filepath.LastIndexOf(@"/") + 1);
        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="_filepath">文件相对路径</param>
        /// <returns>bool</returns>
        public static bool FileExists(string _filepath)
        {
            string fullpath = GetMapPath(_filepath);
            if (File.Exists(fullpath))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获得远程字符串
        /// </summary>
        public static string GetDomainStr(string key, string uriPath)
        {
            string result = CacheHelper.Get(key) as string;
            if (result == null)
            {
                WebClient client = new WebClient();
                try
                {
                    client.Encoding = Encoding.UTF8;
                    result = client.DownloadString(uriPath);
                }
                catch
                {
                    result = "暂时无法连接!";
                }
                CacheHelper.Insert(key, result, 60);
            }

            return result;
        }

        /// <summary>
        /// 写文件（）
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="content">内容</param>
        /// <param name="isAppend">是否追加</param>
        public static bool WriteFile(string path, string content, bool isAppend = false)
        {
            try
            {
                var fullpath = HttpRuntime.AppDomainAppPath + path;
                var sw = new StreamWriter(fullpath, isAppend);
                sw.Write(content);
                sw.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region 读取或写入cookie

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(HttpContext httpContext, string strName, string strValue)
        {
            HttpCookie cookie = httpContext.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            httpContext.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="strName">strName</param>
        /// <param name="key">The key.</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(HttpContext httpContext, string strName, string key, string strValue)
        {
            HttpCookie cookie = httpContext.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            httpContext.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="strName">名称</param>
        /// <param name="key">The key.</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">The expires.</param>
        public static void WriteCookie(HttpContext httpContext, string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = httpContext.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            httpContext.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值
        /// 过期时间(分钟)</param>
        /// <param name="expires">The expires.</param>
        public static void WriteCookie(HttpContext httpContext, string strName, string strValue, int expires)
        {
            HttpCookie cookie = httpContext.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            httpContext.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(HttpContext httpContext, string strName)
        {
            if (httpContext.Request.Cookies[strName] != null)
                return UrlDecode(httpContext.Request.Cookies[strName].Value.ToString());
            return "";
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="strName">名称</param>
        /// <param name="key">The key.</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(HttpContext httpContext, string strName, string key)
        {
            if (httpContext.Request.Cookies[strName] != null &&
                httpContext.Request.Cookies[strName][key] != null)
                return UrlDecode(httpContext.Request.Cookies[strName][key].ToString());

            return "";
        }

        #endregion

        #region 联合分隔符组成的字符串 14-10-18 By 唐有炜

        /// <summary>
        /// 联合分隔符组成的字符串 14-10-18 By 唐有炜
        /// </summary>
        /// <param name="str1">a|b|,a2|b2,a3|b3</param>
        /// <param name="str2">c,d,e</param>
        /// <param name="split">,</param>
        /// <returns>a|b|c,a2|b2|d,a3|b3|e</returns>
        public static string UnionStringsBySplit(string str1, string str2, char split)
        {
            string result = "";
            var arr1 = str1.Split(split);
            var arr2 = str2.Split(split);
            for (int i = 0; i < arr1.Length; i++)
            {
                var tempArr1 = arr1[i];
                tempArr1 += "|" + arr2[i]+",";
                result += tempArr1;
            }
            result = result.TrimEnd(',');
            return result;
        }

        #endregion

        #region 构造动态LINQ查询条件 14-10-21 By 唐有炜
   
       /// <summary>
        /// 构造动态LINQ查询条件 14-10-21 By 唐有炜
       /// </summary>
        /// <param name="fields">字段集合(id,name)</param>
        /// <param name="eqs">判断集合(=,>)</param>
        /// <param name="values">值集合(1,"aaa")【注意：数字型的字符串需要加_s】</param>
        /// <param name="operations">条件集合（or,and）</param>
        /// <returns>条件及参数集合</returns>
       /// <returns></returns>
        public static string BuildPredicate(string fields, string eqs, string values, string operations, out  object[] parms)
        {
            var fieldArray = Utils.StringToObjectArray(fields, ',');
            var eqArray = Utils.StringToObjectArray(eqs, ',');
            var valueArray = Utils.StringToObjectArray(values.ToString(), ',');
            var opArray = Utils.StringToObjectArray(operations, ',');

            string predicate = "true";
            parms = new object[fieldArray.Length];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < fieldArray.Length; i++)
            {
                //字段名称
                var field = fieldArray[i].ToString();
                //操作符(>,=,<,<>)
                string eq = eqArray[i].ToString();
                //字段值
                object value = valueArray[i];
                //与其他条件之间的逻辑关系（and,or）
                var op = opArray[i].ToString();

                //构造条件
                var cond = field + eq + "@" + i;
                if (eq.ToUpper() == "LIKE")
                {

                    cond = String.Concat(new[] {field, ".Contains(", "@" + i, ") "});
                }
                else
                {
                    //最后之前才加关系
                    if (i < fieldArray.Length - 1) {
                        cond = String.Concat(new[] { cond, " ", op, " " }); 
                    }           
                }
                 //累加条件
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    sb.Append(cond);
                }

                //构造参数
                if (!String.IsNullOrEmpty(value.ToString())) {
                    if (Utils.IsNumeric(value))
                    {
                        parms[i] = int.Parse(value.ToString());
                    }
                    else
                    {
                        //修复字符串Bug 141029 唐有炜
                        if (value.ToString().Contains("_s"))
                        {
                            value = value.ToString().Replace("_s", "");
                        }
                        parms[i] = value;
                    }
                }else{
                    parms[i] =0;
                }
               
            }

            predicate = sb.ToString();
            //修复末尾关系
            if (predicate.Length>3&&(predicate.Substring(predicate.Length - 4, 3).ToUpper() == "AND"))
            {
                var end1 = predicate.Substring(predicate.Length - 4, 3).ToUpper();
                if (end1 == "AND")
                {
                    predicate += " true";
                }

            }
            if (predicate.Length > 2 && (predicate.Substring(predicate.Length - 3, 2).ToUpper() == "OR"))
            {
                var end2 = predicate.Substring(predicate.Length - 3, 2).ToUpper();
                if ( end2 == "OR")
                {
                    predicate += " true";
                }

            }
           
           
             return predicate;
        }

        #endregion



     


    }
}