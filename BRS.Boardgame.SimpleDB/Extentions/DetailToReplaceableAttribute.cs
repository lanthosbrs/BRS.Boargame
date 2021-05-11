using Amazon.SimpleDB.Model;
using BRS.Boargame.Shared;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;


namespace BRS.Boardgame.SimpleDB.Extentions
{
    public static class DetailToReplaceableAttribute
    {
        public static List<ReplaceableAttribute> ToReplaceableAttributes(this GameDetail gameDetail)
        {
            var retval = new List<ReplaceableAttribute>();

            foreach (var aProp in typeof(GameDetail).GetProperties())
            {

                var value = GetValue(aProp, gameDetail);
                if (value != null)
                {
                    retval.Add(new ReplaceableAttribute()
                    {
                        Name = aProp.Name,
                        Replace = true,
                        Value = value
                    });
                }
            }

            return retval;
        }

        private static string? GetValue(PropertyInfo propertyInfo, GameDetail gameDetail)
        {

            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                //this needs to be a list of json

                if (propertyInfo.GetValue(gameDetail) != null)
                {
                    var json = JsonSerializer.Serialize(propertyInfo.GetValue(gameDetail));
                    return json;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //this means there is only one property
                return propertyInfo.GetValue(gameDetail)?.ToString();
            }
        }

    }
}

