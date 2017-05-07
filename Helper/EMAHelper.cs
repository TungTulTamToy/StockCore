namespace StockCore.Helper
{
    public class EMAHelper
    {
        public double Value()=>isReady()?emav:0;
        public bool isReady()=>tickcount >= period;
        public EMAHelper(int period)
        {
            this.period = period;
        }
        public void ReceiveTick(double value)
        {
            tickcount++;            
            if (tickcount < period)
            {
                emav += value;
            }
            else if (tickcount == period)
            {
                emav = (emav+value)/(double)period;
            }
            else if (tickcount > period)
            {
                emav = (dampen() * (value - emav)) + emav;
            }
        }
        private double emav;        
        private int tickcount;
        private readonly int period;
        private double dampen()=>2/((double)1.0+period);        
    }
}