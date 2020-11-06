using System;
using System.Collections.Generic;
using System.Text;
using TeachMeSkills.DotNet.FitnessTrackerCore.Enums;

namespace TeachMeSkills.DotNet.FitnessTrackerCore.Models
{
    public class User
    {
        public User()
        {
        }
        
        public User(
            string fullName,
            double weight,
            int height,
            int age,
            Gender gender)
        {
            // check all params

            FullName = fullName;
            Weight = weight;
            Height = height;
            Age = age;
            Gender = gender;
        }

        public string FullName { get; set; }

        public double Weight { get; set; }

        public int Height { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public List<Run> Runs { get; set; } = new List<Run>();

        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
