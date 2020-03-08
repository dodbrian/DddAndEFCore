using System;
using System.Collections.Generic;
using System.Linq;

namespace FollowApp
{
    public class Student : Entity
    {
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();

        public string Name { get; }
        public string Email { get; }
        public virtual Course FavoriteCourse { get; }
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        protected Student() { }

        public Student(string name, string email, Course favoritteCourse) : this()
        {
            Name = name;
            Email = email;
            FavoriteCourse = favoritteCourse;
        }

        public string EnrollIn(Course course, Grade grade)
        {
            if (_enrollments.Any(x => x.Course == course))
                return $"Already enrolled in course '{course.Name}'";

            var enrollment = new Enrollment(course, this, grade);
            _enrollments.Add(enrollment);

            return "OK";
        }

        public void Disenroll(Course course)
        {
            var enrollment = _enrollments.FirstOrDefault(x => x.Course == course);

            if (enrollment == null) return;

            _enrollments.Remove(enrollment);
        }
    }
}