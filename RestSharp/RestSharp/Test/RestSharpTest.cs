using NUnit.Framework;
using RestSharp;
using RestSharp.Models;
using static RestSharpTrain.Utils.TestUtils;
using static RestSharp.API.ApiUtils;
using static RestSharpTrain.Config.ConfigManager;

namespace RestSharpTrain.Test
{
    internal class RestSharpTest
    {
        [Test]
        public void Tests() {
            //first
            string request = new RequestBuilder().Posts().Build();
            RestResponse response = GetRequest(request);
            int statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.OK));
            Assert.IsTrue(JSONUtils<List<Post>>.IsJson(response.Content));
            List<Post> posts = JSONUtils<List<Post>>.DeserializeJson(response.Content);
            Assert.IsTrue(IsInAscendingById(posts));

            //second
            request = new RequestBuilder().Posts()
                .CertainNumber(getIntProperty(KEYS.sec_id)).Build();
            response = GetRequest(request);
            statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.OK));
            Assert.IsTrue(JSONUtils<Post>.IsJson(response.Content));
            Post post = JSONUtils<Post>.DeserializeJson(response.Content);
            Assert.IsTrue(post.id.Equals(getIntProperty(KEYS.sec_id)));
            Assert.IsTrue(post.userId.Equals(getIntProperty(KEYS.sec_userId)));
            Assert.IsFalse(IsEmpty(post.title));
            Assert.IsFalse(IsEmpty(post.body));

            //third
            request = new RequestBuilder().Posts()
                .CertainNumber(getIntProperty(KEYS.third_id)).Build();
            response = GetRequest(request);
            statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.NOT_FOUND));
            Assert.IsTrue(IsBodyEmpty(response));

            //forth
            Post expectedPost = new Post(getIntProperty(KEYS.forth_userId),
                101,
                GetRandomString(),
                GetRandomString());
            RestRequest RestRequestObject = new RequestBuilder().Posts().BuildRestRequest()
                .AddPostAsJsonBody(expectedPost)
                .GetRestRequest();
            response = PostRequest(RestRequestObject);
            statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.CREATED));
            Assert.IsTrue(JSONUtils<Post>.IsJson(response.Content));
            post = JSONUtils<Post>.DeserializeJson(response.Content);
            expectedPost.id = post.id;
            Assert.IsTrue(ArePostsEquals(post, expectedPost));
            Assert.IsTrue(post.id != null);

            //fifth
            request = new RequestBuilder().Users().Build();
            response = GetRequest(request);
            statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.OK));
            Assert.IsTrue(JSONUtils<List<User>>.IsJson(response.Content));
            List<User> users = JSONUtils<List<User>>.DeserializeJson(response.Content);
            User fifthUser = users.Find(user => 
            user.id.Equals(getIntProperty(KEYS.fifth_id)));
            User expectedUser = JSONUtils<User>.DeserializeJson(
                JSONUtils<User>.JsonToString(@"Config/expectedUser.json"));
            Assert.IsTrue(AreUsersEquals(fifthUser, expectedUser));

            //sixth
            request = new RequestBuilder().Users()
                .CertainNumber(getIntProperty(KEYS.fifth_id)).Build();
            response = GetRequest(request);
            statusCode = (int)response.StatusCode;
            Assert.IsTrue(statusCode.Equals((int)STATUS_CODE.OK));
            Assert.IsTrue(JSONUtils<User>.IsJson(response.Content));
            User user = JSONUtils<User>.DeserializeJson(response.Content);
            Assert.IsTrue(AreUsersEquals(user, expectedUser));
        }

    }
}
