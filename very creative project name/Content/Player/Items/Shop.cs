using static very_creative_project_name.Ref;
using System.Collections.Generic;
using System.Linq;

namespace very_creative_project_name
{
    class Shop
    {
        public int[] GetItems()
        {
            HashSet<int> hShopItems = new HashSet<int>();
            while (hShopItems.Count < 3)
            {
                int rolledShop = r.Next(0, inv.armours.Count);
                if (inv.prices[rolledShop] != 0)
                {
                    hShopItems.Add(rolledShop);
                }
            }
            int[] shopItems = new int[3];
            int i = 0;
            foreach (int item in hShopItems)
            {
                shopItems[i] = item;
                i++;
            }
            return shopItems;
        }

        public List<Armour> ShopItems()
        {
            List<Armour> shopItems = new List<Armour>();
            int[] shopItemID = GetItems();
            foreach (Armour arm in inv.armours)
            {
                if (shopItemID.Contains(arm.ID))
                {
                    shopItems.Add(arm);
                }
            }
            return shopItems;
        }
    }
}
