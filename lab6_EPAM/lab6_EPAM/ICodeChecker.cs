using System;

namespace lab6_EPAM
{
    public interface ICodeChecker
    {
        bool CheckCodeSyntax(string s1, string s2);
    }
}