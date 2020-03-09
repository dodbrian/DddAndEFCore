using System.Linq;

namespace FollowApp
{
    public class Course : Entity
    {
        public static readonly Course Calculus = new Course(1, "Calculus");
        public static readonly Course Chemistry = new Course(2, "Chemistry");

        public static readonly Course[] AllCourses = { Calculus, Chemistry };

        public string Name { get; }

        private Course(long id, string name) : base(id)
        {
            Name = name;
        }

        protected Course() { }

        public static Course FromId(long id)
        {
            return AllCourses.SingleOrDefault(x => x.Id == id);
        }
    }
}