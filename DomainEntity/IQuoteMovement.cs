using System;
using System.Collections.Generic;
using System.Linq;

namespace StockCore.DomainEntity
{
    public interface IQuoteMovement:IPersistant,IKeyField<string>
    {
        string Quote{get;set;}
        //double Volumn{get;set;}
        //double Price{get;set;}
        //double Amount{get;set;}
        IEnumerable<Transaction> Transaction{get;set;}
    }
    public class QuoteMovement:Persistant,IQuoteMovement,ILinqCriteria<QuoteMovement>
    {
        public string Key
        {
            get=>Quote;
            set=>Quote=value;
        }
        public string Quote{get;set;}
        //public double Volumn{get;set;}
        //public double Price{get;set;}
        //public double Amount{get;set;}
        public IEnumerable<Transaction> Transaction{get;set;}
        public bool Equals(QuoteMovement other)=>this.Quote == other.Quote;
        public override int GetHashCode()=>this.Quote.GetHashCode();
        public QuoteMovement Merge(QuoteMovement other)
        {
            //this.Volumn = other.Volumn;
            //this.Price = other.Price;
            //this.Amount = other.Amount;
            this.Transaction = other.Transaction;
            return this;
        }
        public bool UpdateCondition(QuoteMovement other)
        {
            var condition = true;
            if(!isNullOrEmpty(this.Transaction) && !isNullOrEmpty(other.Transaction))
            {
                condition = countBuyOrder(this) != countBuyOrder(other) && countSellOrder(this) != countSellOrder(other);
            }
            return condition;
        }
        private bool isNullOrEmpty(IEnumerable<Transaction> transaction)=>Transaction==null || !Transaction.Any();
        private int countSellOrder(QuoteMovement item)=>item.Transaction.Where(t=>t.SellOrder != null).Count();
        private int countBuyOrder(QuoteMovement item)=>item.Transaction.Where(t=>t.BuyOrder != null).Count();
    }
}