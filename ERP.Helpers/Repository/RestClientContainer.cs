using ERP.Front.Helpers.Core;
using ERP.Front.Helpers.Parameters;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ERP.Front.Helpers.Repository
{
    public class RestClientContainer
    {
        private readonly RestClient client;
        private readonly string _serverUri;
        private readonly bool _isTestServer;

        public RestClientContainer(string serverUri)
        {

            _serverUri = serverUri;
            client = new RestClient();
            _isTestServer = (bool)(HttpContext.Current.Session["IsTestSrv"] ?? false);
        }

        public async Task<T> SendRequest<T>(string uri, Method method, object obj = null)
        {
            client.CookieContainer = new CookieContainer();
            string querySrtring = (method == Method.GET && obj != null) ? obj.ToString() : "";
            var Lang = Thread.CurrentThread.CurrentCulture.Name;
            string ServerURL = (_serverUri.ToLower().Contains("://localhost") || _isTestServer) ?
                $"{_serverUri}{uri}{querySrtring}" :
                $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Host}{_serverUri}{uri}{querySrtring}";
            var request = new RestRequest(ServerURL, method);
            if (method == Method.POST || method == Method.PUT)
            {
                request.AddJsonBody(obj);
            }
            var accessToken = HttpContext.Current.Session["token"] == null ? string.Empty : HttpContext.Current.Session["token"].ToString();
            if (!string.IsNullOrEmpty(accessToken)) request.AddParameter("Authorization", "Bearer " + accessToken, ParameterType.HttpHeader);
            request.AddParameter("ReqLang", Lang, ParameterType.QueryStringWithoutEncode);
            var response = await client.ExecuteTaskAsync<T>(request);
            return response.Data;
        }
    }
}
