using System.Collections.Generic;
using TeachMeSkills.DotNet.ZooManagement.Models;

namespace TeachMeSkills.DotNet.ZooManagement.Interfaces
{
    public interface IZooManager
    {
        List<AnimalBase<int>> Animals { get; set; }

        void Show();
    }
}
