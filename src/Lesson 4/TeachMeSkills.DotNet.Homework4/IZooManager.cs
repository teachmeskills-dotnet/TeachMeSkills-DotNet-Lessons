using System.Collections.Generic;

namespace TeachMeSkills.DotNet.Homework4
{
    public interface IZooManager
    {
        List<AnimalBase<int>> Animals { get; set; }

        void Show();
    }
}
