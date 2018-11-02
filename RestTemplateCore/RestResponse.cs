using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace RestTemplateCore
{
    /// <summary>
    /// Rest响应结果
    /// </summary>
    public class RestResponse
    {
        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 响应的报文头
        /// </summary>
        public HttpResponseHeaders Headers { get; set; }
    }
}
