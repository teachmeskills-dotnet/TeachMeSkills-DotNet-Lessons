using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.DotNet.ApiApplicationCore.Constants;
using TeachMeSkills.DotNet.ApiApplicationCore.Interfaces;
using TeachMeSkills.DotNet.ApiApplicationCore.Models;

namespace TeachMeSkills.DotNet.ApiApplicationCore.Services
{
    public class RequestService : IRequestService
    {
        public async Task<MainResponse> SearchAsync(string str)
        {
            return await Common.Url
                .AppendPathSegments("api", "json", "v1", "1", "search.php")
                .SetQueryParams(new { s = str })
                .GetJsonAsync<MainResponse>();
        }
    }
}
