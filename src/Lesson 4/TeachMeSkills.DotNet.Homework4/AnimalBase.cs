namespace TeachMeSkills.DotNet.Homework4
{
    public abstract class AnimalBase<T>
    {
        public string Name { get; set; }

        public T Age { get; set; }
    }
}
