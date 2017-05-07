using System.Collections.Generic;
using StockCore.DomainEntity;

namespace StockCore.Helper
{
    public class MovingAverageHelper
    {
        private readonly EMAHelper slowEMA, fastEMA, signalEMA;
        public MovingAverageHelper(int fastEmaPeriod, int slowEmaPeriod, int signalEmaPeriod)
        {
            fastEMA = new EMAHelper(fastEmaPeriod);            
            slowEMA = new EMAHelper(slowEmaPeriod);
            signalEMA = new EMAHelper(signalEmaPeriod);
        }
        public void ReceiveTick(double value)
        {
            fastEMA.ReceiveTick(value);            
            slowEMA.ReceiveTick(value);
            if (slowEMA.isReady())
            {
                signalEMA.ReceiveTick(fastEMA.Value()-slowEMA.Value());
            }
        }
        public MovingAverage Value()
        {
            MovingAverage item = null;
            if (signalEMA.isReady())
            {
                var signal = signalEMA.Value();
                var macd = fastEMA.Value() - slowEMA.Value();
                item = new MovingAverage()
                {
                    MACD=macd,
                    Signal=signal,
                    Hist=macd - signal
                };                
            }
            return item;
        }
    }
}