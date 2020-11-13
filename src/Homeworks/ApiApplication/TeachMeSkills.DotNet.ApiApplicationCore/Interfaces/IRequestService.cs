using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeachMeSkills.DotNet.ApiApplicationCore.Models;

namespace TeachMeSkills.DotNet.ApiApplicationCore.Interfaces
{
    public interface IRequestService
    {
        Task<MainResponse> SearchAsync(string str);
    }
}
