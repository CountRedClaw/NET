namespace part2
{
    public interface IFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
}