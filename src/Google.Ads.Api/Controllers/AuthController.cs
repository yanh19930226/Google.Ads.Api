using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Google.Ads.Api.Controllers
{

    /// <summary>
    /// 权限认证管理
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("Api/Auth")]
    public class AuthController : Controller
    {
        private readonly Appsettings _settings;
        public AuthController(IOptions<Appsettings> options)
        {
            _settings = options.Value;
        }
        /// <summary>
        /// 获取登入Google链接
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetGoogleLoginUrl")]
        public GoogleResult<string> GetGoogleLoginUrl()
        {
            var res = new GoogleResult<string>();

            //var oidcurl = "https://accounts.google.com/o/oauth2/v2/auth?redirect_uri=http://localhost/oauth2callback&prompt=consent&response_type=code&client_id=298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fadwords+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fdfp+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.email+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.profile+openid&access_type=offline";

            var url = "https://accounts.google.com/o/oauth2/auth?redirect_uri=http://localhost/oauth2callback&prompt=consent&response_type=code&client_id=298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fadwords+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fdfp+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.email+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.profile+openid&access_type=offline";

            res.Success(url, GoogleResultCode.Succeed.ToString());

            return res;
        }

        /// <summary>
        /// 根据授权码获取AccessToken
        /// </summary>
        /// <param name="code">授权码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTokenUserAsync")]
        public AccessTokenResponse GetTokenUserAsync(string code)
        {

            AccessTokenRequest req = new AccessTokenRequest()
            {
                code = code,
                client_id = "298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com",
                 client_secret = "FnwDNLJt_Rqf_-CM3YjO8F6c",
                redirect_uri = "http://localhost/oauth2callback",
                grant_type = "authorization_code",
            };

            //var oidcurl = "https://oauth2.googleapis.com/token";

            var url = "https://accounts.google.com/o/oauth2/token";

            try
            {
                HttpClient httpClient = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(req);  //convert to JSON
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);  //convert to key/value pairs
                string urlEncodedData = ConcatQueryString(values);
                HttpContent payload = new StringContent(urlEncodedData, Encoding.UTF8, "application/x-www-form-urlencoded");
                var msg = httpClient.PostAsync(url, payload).Result;
                string responseBodyAsText = msg.Content.ReadAsStringAsync().Result;

                AccessTokenResponse obj = JsonConvert.DeserializeObject<AccessTokenResponse>(responseBodyAsText);
                //获取用户信息

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 使用RefreshToken刷新AccessToken
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTokenWithRefreshToken")]
        public RefreshTokenResponse GetTokenWithRefreshToken(string refreshToken)
        {

            RefreshTokenRequest req = new RefreshTokenRequest()
            {
                client_id = "298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com",
                client_secret = "FnwDNLJt_Rqf_-CM3YjO8F6c",
                refresh_token = refreshToken,
                grant_type = "refresh_token",
            };

            var url = "https://accounts.google.com/o/oauth2/token";

            try
            {
                HttpClient httpClient = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(req);  //convert to JSON
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);  //convert to key/value pairs
                string urlEncodedData = ConcatQueryString(values);
                HttpContent payload = new StringContent(urlEncodedData, Encoding.UTF8, "application/x-www-form-urlencoded");
                var msg = httpClient.PostAsync(url, payload).Result;
                string responseBodyAsText = msg.Content.ReadAsStringAsync().Result;

                //如果刷新令牌过期重定向到登入页面,可以选择是否重新让用户确认授予的权限确认框,如果不需要请求地址不要带上promt=consent
                //{
                //    "error": "invalid_grant",
                //   "error_description": "Bad Request"
                //}

                if (true)
                {
                    var Redirecturl = "https://accounts.google.com/o/oauth2/auth?redirect_uri=http://localhost/oauth2callback&response_type=code&client_id=298324624669-kachgof1usnvgi9lc75f11fct1348met.apps.googleusercontent.com&scope=https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fadwords+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fdfp+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.email+https%3A%2F%2Fwww.googleapis.com%2Fauth%2Fuserinfo.profile+openid&access_type=offline";

                    //return Redirect(Redirecturl);
                }

                RefreshTokenResponse obj = JsonConvert.DeserializeObject<RefreshTokenResponse>(responseBodyAsText);

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string Encode(string value)
        {
            return HttpUtility.UrlEncode(value, Encoding.UTF8);
        }

        /// <summary>
        /// 构造键值参数字符串UTF-8
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string ConcatQueryString(Dictionary<string, string> parameters)
        {
            if (null == parameters)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();

            foreach (var entry in parameters)
            {
                string key = entry.Key;
                string val = entry.Value;

                sb.Append(Encode(key));
                if (val != null)
                {
                    sb.Append("=").Append(Encode(val));
                }
                sb.Append("&");
            }

            int strIndex = sb.Length;
            if (parameters.Count > 0)
                sb.Remove(strIndex - 1, 1);
            return sb.ToString();
        }

        public class AccessTokenRequest
        {
            public string code { get; set; }
            public string client_id { get; set; }
            public string client_secret { get; set; }
            public string redirect_uri { get; set; }
            public string grant_type { get; set; }
        }

        public class AccessTokenResponse
        {
            /// <summary>
            /// 只返回认证信息
            /// </summary>
            public string access_token { get; set; }
            /// <summary>
            /// oidcToken(认证和授权信息)
            /// </summary>
            public string id_token { get; set; }
            public string expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
            public string refresh_token { get; set; }

        }

        public class RefreshTokenRequest
        {
            public string client_id { get; set; }
            public string client_secret { get; set; }
            public string refresh_token { get; set; }
            public string grant_type { get; set; }
        }

        public class RefreshTokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }

        public class UserInfoResponse
        {
            /// <summary>
            /// family_name
            /// </summary>
            public string family_name { get; set; }
            /// <summary>
            /// name
            /// </summary>
            public string name { get; set; }
            public string picture { get; set; }
            public string locale { get; set; }
            public string email { get; set; }
            public string given_name { get; set; }
            public string id { get; set; }
            public string verified_email { get; set; }
        }
    }
}
