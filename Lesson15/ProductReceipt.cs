using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public class ProductReceipt
    {
        public Guid ReceiptId { get; set; }
        public Guid ProductId { get; set; }
        public ProductReceipt( Guid receiptId, Guid productId)
        {
            ReceiptId = receiptId;
            ProductId = productId;
        }
        public override string ToString() => $"{ReceiptId}, {ProductId}";
    }
}
