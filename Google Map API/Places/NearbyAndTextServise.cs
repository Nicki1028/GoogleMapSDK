﻿using Google_Map_API.Geocoding;
using GoogleApi.Entities.Maps.Common;
using HttpUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Google_Map_API.Places
{
    public class NearbyAndTextServise
    {
        private HttpRequest _HttpRequest;


        public NearbyAndTextServise(HttpRequest httpRequest)
        {
            _HttpRequest = httpRequest;
        }

        public async Task<NearbyAndTextResponse> TextSearch(TextSearchRequest textSearchRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?" + baseService.ToUri(textSearchRequest) + "&key=" + GoogleSigned.SigningInstance._key;

            return await _HttpRequest.Get<NearbyAndTextResponse>(url);
        }

        public async Task<NearbyAndTextResponse> NearbySearch(NearbySearchRequest nearbySearchRequest)
        {
            BaseService baseService = new BaseService();

            string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?" + baseService.ToUri(nearbySearchRequest) + "&key=" + GoogleSigned.SigningInstance._key;
            
            return await _HttpRequest.Get<NearbyAndTextResponse>(url);
        }
    }
}