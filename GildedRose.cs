using System.Collections.Generic;

namespace csharp
{
    public class Commun : Item
    {
        public Commun() : base("Commun")
        {
        }
    }
    public class Legendary : Item
    {
        public Legendary() : base("Legendary")
        {
        }
    }
    public class Cheese : Item
    {
        public Cheese() : base("Cheese")
        {
        }
    }
    public class Concert : Item
    {
        public Concert() : base("Concert")
        {
        }
    }
    public class Conjured : Item
    {
        public Conjured() : base("Conjured")
        {
        }
    }
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].SellIn--;
                switch (Items[i].Category)
                {
                    case "Commun":
                        if (Items[i].SellIn >= 0)
                        {
                            Items[i].Quality--;
                        }
                        else
                        {
                            Items[i].Quality--;
                            Items[i].Quality--;
                        }
                        break;

                    case "Legendary":
                        Items[i].SellIn = 0;
                        Items[i].Quality = Items[i].Quality;
                        break;

                    case "Cheese":
                        Items[i].Quality++;
                        break;

                    case "Concert":
                        if (Items[i].SellIn > 10) {
                            Items[i].Quality++;
                        } else if (Items[i].SellIn > 5) {
                            Items[i].Quality++;
                            Items[i].Quality++;
                        } else if (Items[i].SellIn > 0)
                        {
                            Items[i].Quality++;
                            Items[i].Quality++;
                            Items[i].Quality++;
                        } else {
                            Items[i].Quality = 0;
                        }
                        break;

                    case "Conjured":
                        if (Items[i].SellIn >= 0) {
                            Items[i].Quality--;
                            Items[i].Quality--;
                        } else {
                            Items[i].Quality--;
                            Items[i].Quality--;
                            Items[i].Quality--;
                            Items[i].Quality--;
                        }
                        break;
                }
                
                if (Items[i].Quality < 0)
                {
                    Items[i].Quality = 0;
                }
                if (Items[i].Quality >= 50)
                {
                    Items[i].Quality = 50;
                }
            }
        }
    }
}
