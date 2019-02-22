﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore;
using HoneySheet.EfCore.Models;
using HoneySheet.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// 定义权限管理控制器
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthorityController : ControllerBase
    {
        public AuthorityController(AuthorityService service)
        {
            this._service = service;
        }

        private AuthorityService _service;

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="info">用户登录请求对象</param>
        /// <returns>返回登录证书对象</returns>
        [HttpPost("login")]
        public async Task<ActionResult<Credential>> Login([FromBody]LoginInfo info)
        {
            if (info == null) return NotFound();
            if (string.IsNullOrEmpty(info.Password) || string.IsNullOrEmpty(info.UserName))
                return NotFound();
            return await Task.Factory.StartNew<Credential>(() => _service.Login(info));
        }
    }
}