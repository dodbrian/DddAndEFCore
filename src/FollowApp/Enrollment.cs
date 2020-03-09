namespace FollowApp
{
    public class Enrollment : Entity
    {
        public Course Course { get; }
        public Student Student { get; }
        public Grade Grade { get; }

        public Enrollment(Course course, Student student, Grade grade)
        {
            Course = course;
            Student = student;
            Grade = grade;
        }
    }

    public enum Grade
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        F = 4
    }
}