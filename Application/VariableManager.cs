using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class VariableManager
    {

        public static string RemoveSpace(string text)
        {
            return text.Replace(" ", "%20");
        }
    }
}
