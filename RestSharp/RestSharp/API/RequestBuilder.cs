using RestSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp.API
{
    internal class RequestBuilder
    {
        public string Request { get; set; } = "/";
        public RestRequest RestRequestObject { get; set; }
        public RequestBuilder Posts() {
            this.Request = $"{this.Request}posts/";
            return this;
        }

        public RequestBuilder Users()
        {
            this.Request = $"{this.Request}users/";
            return this;
        }

        public RequestBuilder CertainNumber(int postNumber)
        {
            this.Request = $"{this.Request}{postNumber}/";
            return this;
        }

        public string Build() {
            RestRequestObject = new RestRequest(this.Request);
            return this.Request;
        }

        public RequestBuilder BuildRestRequest() {
            RestRequestObject = new RestRequest(this.Request);
            return this;
        }

        public RestRequest GetRestRequest()
        {
            return this.RestRequestObject;
        }

        public RequestBuilder AddUserId(int userId) {
            RestRequestObject.AddParameter<Int32>("userId", userId);
            return this;
        }

        public RequestBuilder AddBody(string body)
        {
            RestRequestObject.AddParameter("body", body);
            return this;
        }

        public RequestBuilder AddTitle(string title)
        {
            RestRequestObject.AddParameter("title", title);
            return this;
        }

        public RequestBuilder AddPostAsJsonBody(Post post) {
            RestRequestObject.AddJsonBody<Post>(post);
            return this;
        }
    }
}
