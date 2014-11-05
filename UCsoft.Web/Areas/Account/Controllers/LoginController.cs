// ***********************************************************************
// Assembly         : Ed.Web
// Author           : Tangyouwei
// Created          : 2014-10-14 21:34:34
//
// Last Modified By : Tangyouwei
// Last Modified On : 2014-10-13 20:09:45
// ***********************************************************************
// <copyright file="LoginController.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCsoft.Common;
using UCsoft.Entity;
/// <summary>
/// The Controllers namespace.
/// </summary>
//using Ed.Common;
//using Ed.Entity;
//using Ed.Service;
//using Ed.Web.Filters;
using UCsoft.Service;

namespace UCsoft.Web.Areas.Account.Controllers
{
    /// <summary>
    /// Class LoginController.
    /// 2014-10-13 20:09:45 修改 By 唐有炜
    /// </summary>
    public class LoginController : Controller
    {
        #region  依赖注入 2014-10-13 18:51:08 By 唐有炜

        public ITSysUserService TSysUserService { set; get; }
        public IAccountService AccountService { set; get; }

        #endregion

        #region 登陆首页

        //
        // GET: /Account/Login/

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        //[AutoLogin]
        public ActionResult Index()
        {
            LogHelper.Debug("您打开了登录首页。");
            return View();
        }

        #endregion

        #region 登录提交

        //
        // GET: /Account/Login/DoLogin 登录提交
        [HttpPost]
        public ActionResult DoLogin(FormCollection fc)
        {
            ResponseMessage rmsg=new ResponseMessage();
            try
            {
                //LogHelper.Info("来自" + HttpUtility.UrlDecode(fc["clientPlace"].ToString()) + "的" +
                //LogHelper.Info(fc["userName"].ToString() + "正在登录...");
                //rmsg = AccountService.Login(System.Web.HttpContext.Current, fc["type"].ToString(),
                //    fc["accountType"].ToString(), fc["userName"].ToString(), fc["userPassword"].ToString(),
                //    fc["remember"].ToString(),
                //    fc["clientIp"].ToString(), HttpUtility.UrlDecode(fc["clientPlace"].ToString()),
                //     fc["clientTime"].ToString());
            }
            catch (Exception ex)
            {
                //LogHelper.Error("登录异常," + ex.Message);
                //rmsg = new ResponseMessage() {Status = false, Msg = "登录异常，请联系管理员！"};
            }

            return Json(rmsg);
        }

        #endregion

        #region 账户验证

        //
        // GET: /Account/Login/ValidateAccount/ 账户验证 
        public string ValidateAccount(string validate_action, string type, string accountType, string userName,
            string userPassword = null)
        {
            userName = HttpUtility.UrlDecode(userName);
            ResponseMessage rmsg = null;
            //rmsg = AccountService.ValidateAccount(type, accountType,
            //    userName, userPassword);
            return rmsg.Status.ToString().ToLower();
        }

        #endregion



        #region 退出

        public ActionResult Logout()
        {
            //Session.Remove(EdKeys.SESSION_USER_ID);
            //Session.Remove(EdKeys.SESSION_USER_NAME);
            return View("Index");
        }

        #endregion

        #region 忘记密码

        //
        // GET: /Account/ForgetPassword/

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ForgetPassword()
        {
            return View();
        }

        #endregion
    }
}