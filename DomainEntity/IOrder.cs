using System;

namespace StockCore.DomainEntity
{
    public interface IOrder
    {
        DateTime Date{get;set;}
        double Price{get;set;}
        double Amount{get;set;}
        double Volumn{get;set;}
    }
    public class Order:IOrder
    {
        public DateTime Date{get;set;}
        public double Price{get;set;}
        public double Amount{get;set;}
        public double Volumn{get;set;}
    }
}