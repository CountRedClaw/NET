using System;
using System.Collections.Generic;

namespace lab11_EPAM
{
    public class Test : IEquatable<Test>, IComparable<Test>, IComparer<Test>
    {
        private string _student;
        private string _testTitle;
        private int _date;
        private int _mark;

        public string Student
        {
            get { return _student; }
            private set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _student = value;
            }
        }

        public string TestTitle
        {
            get { return _testTitle; }
            private set
            {
                if (ReferenceEquals(value, null))
                    throw new ArgumentNullException();
                _testTitle = value;
            }
        }

        public int Mark
        {
            get { return _mark; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException();
                _mark = value;
            }
        }

        public int Date
        {
            get { return _date; }
            private set
            {
                _date = value;
            }

        }

        public Test(string student, string testTitle, int mark, int date)
        {
            Student = student;
            TestTitle = testTitle;
            Mark = mark;
            Date = date;
        }

        public bool Equals(Test other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqulsPropertys(ref other);
        }

        private bool EqulsPropertys(ref Test other)
        {
            if (other.Student != Student)
                return false;
            if (other.TestTitle == TestTitle)
                return false;
            if (other.Mark == Mark)
                return false;
            if (other.Date == Date)
                return false;
            return true;
        }

        public int CompareTo(Test other)
        {
            if (ReferenceEquals(null, other))
                throw new ArgumentNullException();
            if (other.Mark < Mark) return 1;
            if (other.Mark > Mark) return -1;
            return 0;
        }
        
        public int Compare(Test x, Test y)
        {
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y))
                throw new ArgumentNullException();
            return x.CompareTo(y);
        }

        public override string ToString() => $"Test {TestTitle} {Date} {Student} mark {Mark}.";
    }
}