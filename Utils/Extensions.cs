using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Restfulapi.Utils
{
    public static class Extensions
    {
        public static HttpResponseMessage GetHttpResponseInstance(this object objJsonNetResult)
        {

            HttpContext.Current.Response.Cache.VaryByHeaders["Accept-encoding"] = true;
            var responseWrap = ValidateandBuildResponseData(objJsonNetResult);
            var stringContent = new StringContent(JsonConvert.SerializeObject(responseWrap, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
            var responseHttp = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = stringContent
            };
            responseHttp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return responseHttp;
        }


        private static ResponseWrapper<object> ValidateandBuildResponseData(object unFormattedResponse)
        {
            var responseData = new ResponseWrapper<object>()
            {
                metaData = GetMetatdata(unFormattedResponse),
                data = unFormattedResponse
            };
            return responseData;
        }
        private static Metadata GetMetatdata(object data, bool isError = false, string errorCode = "", string errorDescription = "")
        {

            var errorObject = new ErrorReponse();
            errorObject.code = errorCode;
            errorObject.message = errorDescription;
            return new Metadata()
            {
                description = data == null ? "Data Not Available" : "Transaction Successful",
                error = errorObject
            };
        }




    }
}