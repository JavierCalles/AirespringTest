using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestJavierCalles.Service.RemoteServices
{
    public class RestApiConsumer
    {
        private readonly RestClient _restClient;

        /// <summary>
        /// Initialization RestClient object
        /// </summary>
        /// <param name="url">url of service that you want use</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RestApiConsumer(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException(nameof(url));

            _restClient = new RestClient(url);
        }

        /// <summary>
        /// Generic method for consume a service with body.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="controller">Name of controller</param>
        /// <param name="action">Name of action controller</param>
        /// <param name="request">Values of body</param>
        /// <param name="method">Type of call</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TResponse Consume<TResponse>(string controller, string action, object request, Method method = Method.GET)
           where TResponse : new()
        {
            var restRequest = new RestRequest($"/{controller}/{action}", method);
            restRequest.AddJsonBody(request);
            restRequest.Timeout = 600000;
            var restResponse = _restClient.Execute<TResponse>(restRequest);


            if (restResponse.ErrorException != null)
                throw new Exception(restResponse.ErrorMessage, restResponse.ErrorException);

            return restResponse.Data;
        }

        /// <summary>
        /// Generic method for consume a service without body.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="controller">Name of controller</param>
        /// <param name="action">Name of action controller</param>
        /// <param name="method">Type of call</param>
        public TResponse Consume<TResponse>(string controller, string action, Method method = Method.GET)
           where TResponse : new()
        {
            var restRequest = new RestRequest($"/{controller}/{action}", method);
            restRequest.Timeout = 600000;
            var restResponse = _restClient.Execute<TResponse>(restRequest);


            if (restResponse.ErrorException != null)
                throw new Exception(message: restResponse.ErrorMessage, innerException: restResponse.ErrorException);

            return restResponse.Data;
        }


    }
}