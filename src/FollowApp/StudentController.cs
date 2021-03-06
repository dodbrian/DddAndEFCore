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

        public string RegisterStudent(
            string name, string email, long favoriteCourseId, Grade favoriteCourseGrade)
        {
            var favoriteCourse = Course.FromId(favoriteCourseId);
            if (favoriteCourse == null) return "Course not found";

            var student = new Student(name, email, favoriteCourse, favoriteCourseGrade);

            _repository.Save(student);
            _context.SaveChanges();

            return "OK";
        }

        public string EditPersonalInfo(
            long studentId, string name, string email, long favoriteCourseId)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
                return "Student not found";

            var favoriteCourse = Course.FromId(favoriteCourseId);
            if (favoriteCourse == null)
                return "Course not found";

            student.Name = name;
            student.Email = email;
            student.FavoriteCourse = favoriteCourse;

            _context.SaveChanges();

            return "OK";
        }
    }
}