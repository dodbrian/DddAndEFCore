using System;

namespace FollowApp
{
    public class Course : Entity
    {
        public string Name { get; }

        public static Course FromId(long courseId)
        {
            throw new NotImplementedException();
        }
    }
}