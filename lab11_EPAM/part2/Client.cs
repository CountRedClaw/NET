namespace part2.concrete
{
    public class Client
    {
        private IChair _abstractChair;
        private ITable _abstractTable;

        public Client(IFactory factory)
        {
            _abstractTable = factory.CreateTable();
            _abstractChair = factory.CreateChair();
        }

        public void Run()
        {
            _abstractChair.Do();

            _abstractTable.Do();
        }
    }
}