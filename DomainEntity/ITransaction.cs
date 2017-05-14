namespace StockCore.DomainEntity
{
    public interface ITransaction
    {
        Order BuyOrder{get;set;}
        Order SellOrder{get;set;}
    }
    public class Transaction:ITransaction
    {
        public double Volumn{get;set;}
        public Order BuyOrder{get;set;}
        public Order SellOrder{get;set;}
    }
}