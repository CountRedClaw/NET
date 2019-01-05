namespace lab6_EPAM
{
    class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string s)
        {
            return "Преобразовано в C#";
        }

        public string ConvertToVB(string s)
        {
            return "Преобразовано в VB";
        }
    }
}