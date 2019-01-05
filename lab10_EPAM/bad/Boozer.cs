using System;

namespace bad
{
    class Boozer
    {
        public int BoozeAmount { get; private set; }

        public event EventHandler OilEnded;

        public Boozer()
        {
            BoozeAmount = 100;
        }

        public void LetsGoDrink()
        {
            Worker();
        }

        private void Worker()
        {
            for (int i = BoozeAmount; i >= 0; i--)
            {
                if (BoozeAmount == 0)
                {
                    if (OilEnded != null)
                    {
                        OilEnded(this, new EventArgs());
                    }
                }

                BoozeAmount--;
            }
        }
    }
}
