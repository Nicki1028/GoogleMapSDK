using GoogleMapSDK.API.Attributes;
using GoogleMapSDK.API.Enums;
using GoogleMapSDK.API.Place_Photo;
using GoogleMapSDK.UI.Contract.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GoogleMapSDK.API
{
    public class BaseService
    {
        public string ToUri(BaseRequest request)
        {
            var qsb = new QueryStringBuilder();

            ProcessProperties(qsb, request);
            qsb.Delete("searchtype");

            string url = qsb.Combine();
            return url;
        }
        //public string ToUri(PlacePhotoRequest request)
        //{
        //    var qsb = new QueryStringBuilder();

        //    ProcessProperties(qsb, request);
        //    qsb.Delete("searchtype");

        //    string url = qsb.Combine();
        //    return url;
        //}
        private void ProcessProperties(QueryStringBuilder strbuilder, object obj, bool restructure = false)
        {
            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
            {
                var optional = prop.GetCustomAttribute<OptionalAttribute>();
                var required = prop.GetCustomAttribute<RequiredAttribute>();
                var value = prop.GetValue(obj);

                if (required != null && value == null)
                {
                    throw new InvalidOperationException($"{prop.Name} is required.");
                }

                if (optional != null && value == null)
                {
                    throw new InvalidOperationException($"{prop.Name} is required to be more than 0.");
                }

                if (value != null)
                {
                    if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                    {
                        if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                            return;

                        var classattribute = prop.GetCustomAttribute<Classtostr>();
                        bool re = classattribute != null;
                        ProcessProperties(strbuilder, value, re);
                        if (re)
                        {
                            //strbuilder.Restructure(classattribute._rename, System.Web.HttpUtility.UrlEncode(classattribute._symbol));
                            strbuilder.Restructure(classattribute._rename, classattribute._symbol);
                        }
                    }
                    else
                    {
                        string name = restructure ? "Re-" + prop.Name : prop.Name;
                        strbuilder.Append(name, value.ToString());
                    }
                }
            }

            //var props = obj.GetType().GetProperties();
            //foreach (var prop in props)
            //{
            //    var itemvalue = prop.GetValue(obj);

            //    if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
            //    {
            //        Getproperty(strbuilder, itemvalue);
            //    }
            //    else
            //    {
            //        strbuilder.Append(prop.Name, itemvalue.ToString());
            //    }
            //}
        }
        public string PlaceSearchtype(EnumPlaceSearchtype placesearchType)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();
            string value = "";
            switch (placesearchType)
            {
                case EnumPlaceSearchtype.Basic:
                    fields.Add("Basic", "formatted_address%2Cgeometry%2Cicon%2Cname%2Cplace_id%2Cphoto%2Ctype");
                    fields.TryGetValue("Basic", out string basic);
                    value = basic;
                    break;
                case EnumPlaceSearchtype.Contact:
                    fields.Add("Contact", "opening_hours");
                    fields.TryGetValue("Contact", out string contact);
                    value = contact;
                    break;
                case EnumPlaceSearchtype.Atmosphere:
                    fields.Add("Atmosphere", "%2Cdelivery%2Cprice_level%2Crating%2Creservable%2Creviews%2Cserves_beer%2Cserves_breakfast%2Cserves_brunch%2Cserves_dinner%2Cserves_lunch%2Cserves_vegetarian_food%2Cserves_wine%2Ctakeout%2Cuser_ratings_total");
                    fields.TryGetValue("Atmosphere", out string atmosphere);
                    value = atmosphere;
                    break;
            }
            return value;
        }

    }
}
