namespace TeachMeSkills.DotNet.ZooManagement.Models
{
    public abstract class AnimalBase<T>
    {
        public string Name { get; set; }

        public T Age { get; set; }
    }
}
