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
}