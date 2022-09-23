using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.API
{
    public sealed class Response
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }
        public string Content { get; set; }


        public async static Task<Response> Get(string url)
        {
            Response r = new();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    using(HttpContent hc = res.Content)
                    {
                        r.Content = await hc.ReadAsStringAsync();
                        r.StatusCode = res.StatusCode;
                        r.Success = res.IsSuccessStatusCode;
                        return r;
                    }
                }

            }
        }
    }
}
