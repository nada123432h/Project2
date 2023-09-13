using System;
using System.Collections.Generic;
using System.Text;

namespace amazon.Models
{
 public  class ShoesModel
    {
        
            public int Id { get; set; }
            public int itemSize { get; set; }
            public string ImgName { get; set; }
            public double ItemPrice { get; set; }
        public bool IsFavourite { get; set; }

    }
}
