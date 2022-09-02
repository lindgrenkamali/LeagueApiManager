using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.API
{
    public class Response
    {
        public async static Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        using (HttpContent content = res.Content)
                        {
                            return await content.ReadAsStringAsync();

                        }
                    }

                    else
                    {
                        return "";
                    }

                }
            }
        }
    }
}
