﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstPractice.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; } 
        public IList<Tag> Tags { get; set; }

        public Course()
        {
            Tags = new List<Tag>(); 
        }
    }
}
