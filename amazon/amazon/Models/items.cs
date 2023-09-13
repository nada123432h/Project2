using System;
using System.Collections.Generic;
using System.Text;

namespace amazon.Models
{
 public   class items
    {
       
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public decimal SalesPrice { get; set; }
            public decimal PurchasePrice { get; set; }
            public int CategoryId { get; set; }
            public string ImageName { get; set; }
        public bool IsFavourite { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return ItemId == ((items)obj).ItemId;
        }

        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
    }
    
}
