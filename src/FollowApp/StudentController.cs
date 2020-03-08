namespace FollowApp
{
    public class StudentController
    {
        private readonly SchoolContext _context;
        private readonly StudentRepository _repository;

        public StudentController(SchoolContext context)
        {
            _context = context;
            _repository = new StudentRepository(context);
        }

        public string CheckStudentFavoriteCourse(long studentId, long courseId)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
                return "Student not found";

            var course = Course.FromId(courseId);
            if (course == null)
                return "Course not found";

            return student.FavoriteCourse == course ? "Yes" : "No";
        }

        public string EnrollStudent(long studentId, long courseId, Grade grade)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
                return "Student not found";

            var course = Course.FromId(courseId);
            if (course == null)
                return "Course not found";

            var result = student.EnrollIn(course, grade);

            _context.SaveChanges();

            return result;
        }

        public string DisenrollStudent(long studentId, long courseId)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
                return "Student not found";

            var course = Course.FromId(courseId);
            if (course == null)
                return "Course not found";

            student.Disenroll(course);

            _context.SaveChanges();

            return "OK";
        }
    }
}