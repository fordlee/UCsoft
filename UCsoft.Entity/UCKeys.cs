using System;

namespace UCsoft.Entity
{
   
    public class UCKeys
    {
        //系统版本
        /// <summary>
        /// 版本号全称
        /// </summary>
        public const string ASSEMBLY_VERSION = "1.0.0";
        /// <summary>
        /// 版本年号
        /// </summary>
        public const string ASSEMBLY_YEAR = "2014";
        //File======================================================
        /// <summary>
        /// 站点配置文件名
        /// </summary>
        public const string FILE_SITE_XML_CONFING = "Configpath";
        /// <summary>
        /// 用户配置文件名
        /// </summary>
        public const string FILE_USER_XML_CONFING = "Userpath";
        /// <summary>
        /// 升级代码
        /// </summary>
        public const string FILE_URL_UPGRADE_CODE = "267C2643EE401DD2F0A06084F7931C4DEC76E7CAA1996481FE8F5081A8936409058D07A6F5E2941C";
        /// <summary>
        /// 消息代码
        /// </summary>
        public const string FILE_URL_NOTICE_CODE = "267C2643EE401DD2F0A06084F7931C4DEC76E7CAA1996481FE8F5081A8936409D037BEA6A623A0A1";

        //Directory==================================================
        /// <summary>
        /// 主题目录
        /// </summary>
        public const string DIRECTORY_THEMES = "Themes";
       
        //Cache======================================================
        /// <summary>
        /// 站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG = "ed_cache_site_config";
        /// <summary>
        /// 用户配置
        /// </summary>
        public const string CACHE_USER_CONFIG = "ed_cache_user_config";
        /// <summary>
        /// 客户端站点配置
        /// </summary>
        public const string CACHE_SITE_CONFIG_CLIENT = "ed_cache_site_client_config";
      
        /// <summary>
        /// 升级通知
        /// </summary>
        public const string CACHE_OFFICIAL_UPGRADE = "ed_official_upgrade";
        /// <summary>
        /// 官方消息
        /// </summary>
        public const string CACHE_OFFICIAL_NOTICE = "ed_official_notice";

        //Session=====================================================        
        /// <summary>
        /// Session超时期限（以分钟为单位）。
        /// </summary>
        public const int SESSION_TIMEOUT = 45;//用户ID
        /// <summary>
        /// 用户
        /// </summary>
        public const string SESSION_USER_ID = "ed_session_user_id";//用户ID
        public const string SESSION_USER_NAME = "ed_session_user_name";//用户名
        /// <summary>
        /// 角色
        /// </summary>
        public const string SESSION_ROLE_ID = "ed_session_role_id";//用户ID
        public const string SESSION_ROLE_NAME = "ed_session_role_name";//用户名

        //Cookies=====================================================
        //Cookies超时期限（以分钟为单位）。
        public const int COOKIE_TIMEOUT = 30 * 24 * 60;
        public const string COOKIE_USER_REMEMBER = "remember";
        /// <summary>
        /// 记住会员用户名
        /// </summary>
        public const string COOKIE_USERNAME_REMEMBER = "userName";
        /// <summary>
        /// 记住会员密码
        /// </summary>
        public const string COOKIE_USERPWD_REMEMBER = "userPassword";
    }
}
