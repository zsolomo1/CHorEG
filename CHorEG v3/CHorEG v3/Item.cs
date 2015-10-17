using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CHorEG_v3
{
    [Serializable]
    public class Item
    {
        public int Item_ID;
        public string Name;
        public int Birthdate;
        public string ImageURL;

        public Item()
        {

        }

        public Item(int anItem_ID, string aName, int aBirthdate, string anImageURL)
        {
            Item_ID = anItem_ID;
            Name = aName;
            Birthdate = aBirthdate;
            ImageURL = anImageURL;
        }
    }
}