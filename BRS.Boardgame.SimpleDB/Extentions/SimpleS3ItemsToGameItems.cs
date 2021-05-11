

using Amazon.SimpleDB.Model;
using BRS.Boargame.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;


namespace BRS.Boardgame.SimpleDB.Extentions
{
    public static class SimpleS3ItemsToGameItems
    {
        public static GameItem ToGameItem(this Item Item)
        {
            var retval = new GameItem();
            retval.Id = Item.Name;
            retval.Name = Item.Attributes.First(x => x.Name == "Name").Value;

            return retval;
        }

        public static List<GameItem> ToGameItems(this IEnumerable<Item> items)
        {
            return items.Select(x => x.ToGameItem()).ToList();
        }

    }
}
