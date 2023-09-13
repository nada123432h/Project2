using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace amazon.Models
{
 public   class clsSlider
    {
        public ObservableCollection<ItemModel> LoaItems() {
            ObservableCollection<ItemModel> lst = new ObservableCollection<ItemModel>();
            ItemModel oItemModel = new ItemModel();
            oItemModel.imgName = "slide1.jpg";

            lst.Add(oItemModel);


             oItemModel = new ItemModel();
            oItemModel.imgName = "slide2.jpg";
            lst.Add(oItemModel);

            oItemModel = new ItemModel();
            oItemModel.imgName = "slide3.jpg";
            lst.Add(oItemModel);

            return lst;




        }

    }
}
