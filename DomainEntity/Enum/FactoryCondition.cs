namespace StockCore.DomainEntity.Enum
{
    public class SyncAllFactoryCondition
    {
        public enum SyncType
        {
            PerQuote,AllQuote
        }
        public SyncType Type;
    }

    public class SyncQuoteFactoryCondition
    {
        public enum SyncType
        {
            MethodOne,MethodTwo
        }
        public SyncType Type;
    }
}