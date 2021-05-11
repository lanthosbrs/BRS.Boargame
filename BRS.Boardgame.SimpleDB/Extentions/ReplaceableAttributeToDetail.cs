

using Amazon.SimpleDB.Model;
using BRS.Boargame.Shared;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;


namespace BRS.Boardgame.SimpleDB.Extentions
{
    public static class ReplaceableAttributeToDetail
    {
        public static GameDetail ToGameDetail(this List<Attribute> attributes)
        {
            var retval = new GameDetail();
            var gameDetailPropInfo = retval.GetType();
            foreach (var anAttribuite in attributes)
            {

                var prop = gameDetailPropInfo.GetProperty(anAttribuite.Name);
                              
                //do the conversion and set it
               prop.SetValue(retval, System.Convert.ChangeType(anAttribuite.Value, prop.PropertyType), null);
            }
          
            return retval;
        }

    }
}
