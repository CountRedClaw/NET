namespace part2.concrete
{
    public class OfficeFurnitureFactory : IFactory
    {
        public IChair CreateChair()
        {
            return new OfficeChair();
        }
        public ITable CreateTable()
        {
            return new OfficeTable();
        }
    }
}