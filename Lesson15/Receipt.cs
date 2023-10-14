using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid BuyerId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public Receipt(Guid id, DateTime date, Guid buyerId, int quantity, decimal totalAmount)
        {
            Id = id;
            Date = date;
            BuyerId = buyerId;
            Quantity = quantity;
            TotalAmount = totalAmount;
        }
        public override string ToString() => $"{Id}, {Date}, {BuyerId}, {Quantity}, {TotalAmount}";
    }
}