using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    internal class IdGenerator
    {
        public static string GenerateCacheKeyFromRequest(HttpRequest request)
        {

            var keybuilder = new StringBuilder();
            keybuilder.Append($"{request.Path}"); //Save the Path

            foreach (var (key,value) in request.Query.OrderBy(a=>a.Key))            
                keybuilder.Append($"|{key}-{value}"); // savequery
            

            return keybuilder.ToString();
        }
    }
}
