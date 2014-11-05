/*
 * ========================================================================
 * Copyright(c) 2013-2014 郑州优创科技有限公司, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[中文姓名]   时间：2014/8/21 9:04:10
 * 文件名：AccountServiceImpl
 * 版本：V1.0.0
 * 
 * 修改者：唐有炜           时间：2014/8/21 9:04:10               
 * 修改说明：修改说明
 * ========================================================================
*/

using System;
using System.Linq;
using System.Web;
using UCsoft.Common;
using UCsoft.Dao;
using UCsoft.Dao.Impl;
using UCsoft.Entity;
using UCsoft.Service;

namespace UCsoft.Service.Impl
{
    public class AccountServiceImpl : IAccountService
    {
        /// <summary>
        /// 注入账户Dao接口 2014-08-26 14:58:50 By 唐有炜
        /// </summary>
        public ITSysUserDao TSysUserDao { set; get; }

        public ITSysRoleDao TSysRoleDao { set; get; }
        public ITSysLogDao TSysLogDao { set; get; }

        #region 账户验证

        /// <summary>
        /// 账户验证 2014/8/21 9:04:10   By 唐有炜
        /// </summary>
        /// <param name="type">注册或登录方式（normal,qrcode,usb,footprint）</param>
        /// <param name="accountType">账号类型（username,email,phone）</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns>ResponseMessage</returns>
        public ResponseMessage ValidateAccount(string type, string accountType, string userName,
            string userPassword = null)
        {
            ResponseMessage rmsg = new ResponseMessage();

            switch (type)
            {
                case "normal": //正常
                    //登录时账户类型不分开
                    if (UserNameExists(accountType, userName))
                    {
                        rmsg.Status = true;
                        rmsg.Msg = "用户名输入正确！";
                        //密码空时只验证用户名
                        if (String.IsNullOrEmpty(userPassword))
                        {
                            return rmsg;
                        }
                    }
                    else
                    {
                        rmsg.Status = false;
                        rmsg.Msg = "该用户名不存在！";
                        return rmsg;
                    }

                    if (UserPasswordExists(accountType, userName, userPassword))
                    {
                        rmsg.Status = true;
                        rmsg.Msg = "密码输入正确！";
                    }
                    else
                    {
                        rmsg.Status = false;
                        rmsg.Msg = "密码错误！";
                        return rmsg;
                    }


                    return rmsg;
                    break;
                default:
                    rmsg.Status = false;
                    rmsg.Msg = "该登录方式尚未开通！";
                    return rmsg;
                    break;
            }
        }

        #region 验证用户名是否存在 2014/8/21 9:04:10   By 唐有炜

        /// <summary>
        /// 验证用户名是否存在 2014/8/21 9:04:10   By 唐有炜
        /// </summary>
        /// <param name="accountType">账号类型（username,email,phone）</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public bool UserNameExists(string accountType, string userName)
        {
            switch (accountType)
            {
                case "username":
                    bool userExists = TSysUserDao.ExistsEntity(u => u.UserLname == userName);
                    if (userExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "email":
                    bool emailExists = TSysUserDao.ExistsEntity(u => u.UserEmail == userName);
                    if (emailExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "phone":
                    bool phoneExists = TSysUserDao.ExistsEntity(u => u.UserPhone == userName);
                    if (phoneExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
                    break;
            }
        }

        #endregion

        #region 验证密码是否正确 2014/8/21 9:04:10   By 唐有炜

        /// <summary>
        /// 验证密码是否正确 2014/8/21 9:04:10   By 唐有炜
        /// </summary>
        /// <param name="accountType">账号类型（username,email,phone）</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns></returns>
        public bool UserPasswordExists(string accountType, string userName, string userPassword)
        {
            bool passwordExists = false;
            //解密
            userPassword = DESEncrypt.Encrypt(userPassword);

            switch (accountType)
            {
                case "username":
                    passwordExists =
                        TSysUserDao.ExistsEntity(
                            u => u.UserLname == userName && u.UserPassword == userPassword);
                    if (passwordExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "email":
                    passwordExists =
                        TSysUserDao.ExistsEntity(
                            u => u.UserEmail == userName && u.UserPassword == userPassword);
                    if (passwordExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case "phone":
                    passwordExists =
                        TSysUserDao.ExistsEntity(
                            u => u.UserPhone == userName && u.UserPassword == userPassword);
                    if (passwordExists)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                default:
                    return false;
                    break;
            }
        }

        #endregion

        #region 书写SesionCookie 2014/8/21 9:04:10   By 唐有炜

        /// <summary>
        /// 书写SesionCookie 2014/8/21 9:04:10   By 唐有炜
        /// </summary>
        /// <param name="sessionHttpContext">HttpContext</param>
        /// <param name="sysUser">用户</param>
        /// <param name="sysRole">角色</param>
        /// <param name="remember">是否记住密码（默认记住）</param>
        public void WriteSessionCookie(HttpContext sessionHttpContext, TSysUser sysUser, TSysRole sysRole,
            string remember = "true")
        {
            sessionHttpContext.Session[UCKeys.SESSION_USER_ID] = sysUser.Id;
            sessionHttpContext.Session[UCKeys.SESSION_USER_NAME] = sysUser.UserTname;
            sessionHttpContext.Session[UCKeys.SESSION_ROLE_ID] = sysRole.Id;
            sessionHttpContext.Session[UCKeys.SESSION_ROLE_NAME] = sysRole.RoleName;
            sessionHttpContext.Session.Timeout = UCKeys.SESSION_TIMEOUT; //默认45分钟
            //记住登录状态下次自动登录
            if (remember.ToLower() == "true")
            {
                //默认30天
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USER_REMEMBER, remember, UCKeys.COOKIE_TIMEOUT);
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USERNAME_REMEMBER, sysUser.UserLname,
                    UCKeys.COOKIE_TIMEOUT);
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USERPWD_REMEMBER, sysUser.UserPassword,
                    UCKeys.COOKIE_TIMEOUT);
            }
            else
            {
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USER_REMEMBER, remember);
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USERNAME_REMEMBER, "");
                Utils.WriteCookie(sessionHttpContext, UCKeys.COOKIE_USERPWD_REMEMBER, "");
            }
        }

        #endregion

        #endregion

        #region 登录提交

        /// <summary>
        /// 登录验证并写入登录日志 2014-08-21 07:58:50 By 唐有炜
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="type">注册或登录方式（normal,qrcode,usb,footprint）</param>
        /// <param name="accountType">账号类型（username,email,phone）</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <param name="remember">记住密码</param>
        /// <param name="clientIp">客户端ip地址</param>
        ///   /// <param name="clientPlace">客户端地址</param>
        /// <param name="clientTime">客户端登录时间</param>
        /// <returns>ResponseMessage</returns>
        public ResponseMessage Login(HttpContext httpContext, string type, string accountType, string userName,
            string userPassword,
            string remember, string clientIp, string clientPlace, string clientTime)
        {
            ResponseMessage rmsg = new ResponseMessage();
            try
            {
                //账户验证
                rmsg = ValidateAccount(type, accountType, userName, userPassword);
                if (!rmsg.Status)
                {
                    return rmsg;
                }
                //判断用户是否被禁用


                //获取用户信息
                var sysUser = GetSysUserByAccountTypeAndUserLname(accountType, userName);
                if (sysUser.UserEnable != 1)
                {
                    rmsg.Status = false;
                    rmsg.Msg = "对不起，该用户已经被禁用！";
                    return rmsg;
                }

                var sysRole = TSysRoleDao.GetEntity(r => r.Id == sysUser.RoleId);
                //书写SessionCookie
                WriteSessionCookie(httpContext, sysUser, sysRole, remember);
                //写日志
                var loginUser = sysUser.UserTname;
                if (String.IsNullOrEmpty(loginUser))
                {
                    if (String.IsNullOrEmpty(clientPlace))
                    {
                        clientPlace = "未知地区";
                    }
                    loginUser = clientPlace + "网友";
                }
                TSysLog sysLog = new TSysLog()
                {
                    UserId = sysUser.Id,
                    UserLname = sysUser.UserLname,
                    LogAction = UCEnums.LogActionEnum.Login.ToString(),
                    LogRemark = String.Concat(new[] {"【", loginUser, "】，登录了系统。"}),
                    LogIp = clientIp,
                    LogPlace = clientPlace,
                    LogTime = DateTime.Parse(clientTime)
                };
                TSysLogDao.InsertEntity(sysLog);

                rmsg.Status = true;
                rmsg.Msg = "登陆成功";
                LogHelper.Info(userName + "登录成功，登录日志已记录。");
            }
            catch (Exception ex)
            {
                rmsg.Status = false;
                rmsg.Msg = "登陆失败";
                LogHelper.Debug("登陆错误", ex);
            }

            return rmsg;
        }

        #region  根据账户类型和用户名获取Model

        /// <summary>
        /// 根据账户类型和用户名获取Model 
        /// </summary>
        /// <param name="accountType">账号类型（username,email,phone）</param>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public TSysUser GetSysUserByAccountTypeAndUserLname(string accountType, string userName)
        {
            TSysUser model = null;
            switch (accountType)
            {
                case "username":
                    model = TSysUserDao.GetEntity(u => u.UserLname == userName);
                    return model;
                    break;
                case "email":
                    model = TSysUserDao.GetEntity(u => u.UserEmail == userName);
                    return model;
                    break;
                case "phone":
                    model = TSysUserDao.GetEntity(u => u.UserPhone == userName);
                    return model;
                    break;
                default:
                    return null;
                    break;
            }
        }

        #endregion

        #endregion
    }
}