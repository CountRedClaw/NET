namespace lab6_EPAM
{
    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public string ConvertToCSharp(string s)
        {
            return "Преобразовано в C#";
        }

        public string ConvertToVB(string s)
        {
            return "Преобразовано в VB";
        }

        public bool CheckCodeSyntax(string s1, string s2)
        {
            return true;
        }
    }
}