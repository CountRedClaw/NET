using System;

namespace bad
{
    public class Gp
    {
        public int SemkiAmount { get; private set; }

        public event EventHandler OilEnded;

        public Gp()
        {
            SemkiAmount = 250;
        }

        public void LetsGoShelkat()
        {
            Worker();
        }

        private void Worker()
        {
            for (int i = SemkiAmount; i >= 0; i--)
            {
                if (SemkiAmount == 0)
                {
                    if (OilEnded != null)
                    {
                        OilEnded(this, new EventArgs());
                    }
                }

                SemkiAmount--;
            }
        }
    }
}