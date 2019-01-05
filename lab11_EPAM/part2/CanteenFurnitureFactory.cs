namespace part2.concrete
{
    public class CanteenFurnitureFactory : IFactory
    {
        public IChair CreateChair()
        {
            return new CanteenChair();
        }
        public ITable CreateTable()
        {
            return new CanteenTable();
        }
    }
}