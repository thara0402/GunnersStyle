using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GunnersStyle.Instapaper
{
    public static class InstapaperHelper
    {
        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public static async Task AuthenticateAsync(string userName, string password)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new Dictionary<string, string>
						{
							{ "username", userName },
							{ "password", password },
						});
                    var res = await client.PostAsync("https://www.instapaper.com/api/authenticate", content);
                    res.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adding URLs to an Instapaper account
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="uri">URL</param>
        /// <returns></returns>
        public static async Task AddAsync(string userName, string password, string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new Dictionary<string, string>
						{
							{ "username", userName },
							{ "password", password },
							{ "url",uri },
						});
                    var res = await client.PostAsync("https://www.instapaper.com/api/add", content);
                    res.EnsureSuccessStatusCode();
                }
            }
            catch (ArgumentException)
            {
                // [net_WebHeaderInvalidControlChars]
                // Arguments:
                // Debugging resource strings are unavailable. 
                // Often the key and arguments provide sufficient information to diagnose the problem. 
                // See http://go.microsoft.com/fwlink/?linkid=106663&Version=4.7.60408.0&File=System.Net.dll&Key=net_WebHeaderInvalidControlChars
                // Parameter name: name

                // WP8.1では成功しているにも関わらず、エラーが返されてしまうので、正常終了として扱う。
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
