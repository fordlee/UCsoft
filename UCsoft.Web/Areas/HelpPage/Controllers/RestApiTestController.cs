using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace UCsoft.Web.Api.Areas.HelpPage.Controllers
{

    public class RestApiTestController : ApiController
    {
        // GET api/restapitest
        /// <summary>
        /// 获取列表  2014-10-13 19:51:21 By 唐有炜
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/restapitest/5
        /// <summary>
        /// 获取一条数据  2014-10-13 19:51:21 By 唐有炜
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public string Get(int id)
        {
            return "value";
        }

        // POST api/restapitest
        /// <summary>
        /// 添加  2014-10-13 19:51:21 By 唐有炜
        /// </summary>
        /// <param name="value">表单值</param>
        public void Post([FromBody]string value)
        {
        }

        // POST api/restapitest/5
        /// <summary>
        /// 修改  2014-10-13 19:51:21 By 唐有炜
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="value">表单值</param>
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/restapitest/5
        /// <summary>
        /// 删除  2014-10-13 19:51:21 By 唐有炜
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
        }
    }
}
