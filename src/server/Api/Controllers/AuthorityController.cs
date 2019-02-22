using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HoneySheet.Model;
using HoneySheet.Model.Dto;
using HoneySheet.Service;

namespace HoneySheet.Api.Controllers
{
    /// <summary>
    /// 定义权限管理控制器
    /// </summary>
    [Route("api/auth")]    
    public class AuthorityController : ApiController
    {                
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">用户登录请求对象</param>
        /// <returns>返回登录证书对象</returns>
        [HttpPost()]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody]LoginInfo info)
        {
            if (info == null) return NotFound();
            if (string.IsNullOrEmpty(info.Password) || string.IsNullOrEmpty(info.UserName))
                return NotFound();

            var service = new AuthorityService();
            var credential = await Task.Factory.StartNew<Credential>(() => service.Login(info));
            return Ok(credential);
        }
    }
}