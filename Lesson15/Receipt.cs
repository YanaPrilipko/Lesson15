using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Buyer Buyer { get; set; }
        public Buyer BuyerId { get; set; }
        public Product[] Product { get; set; }
        public Product ProductId { get; set; }
        public decimal TotalAmount { get;  }
    }
}