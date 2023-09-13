using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace amazon.Models
{
    public static class SharedDataSource
    {
        public static ObservableCollection<items> ShoppingProducts { get; set; } = new ObservableCollection<items>();
    }
}
