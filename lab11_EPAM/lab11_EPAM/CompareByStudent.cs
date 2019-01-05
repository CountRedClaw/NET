using System;
using System.Collections.Generic;

namespace lab11_EPAM
{
    public class CompareByStudent : IComparer<Test>
    {
        public int Compare(Test left, Test right)
        {
            if (ReferenceEquals(null, left) || ReferenceEquals(null, right))
                throw new ArgumentNullException();
            if (String.Compare(left.Student, right.Student) == 1)
                return 1;
            if (String.Compare(left.Student, right.Student) == 0)
                return 0;
            return -1;
        }
    }
}