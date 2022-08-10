using ObjectsComparer;
using RestSharp.Models;

namespace RestSharpTrain.Utils
{
    internal class TestUtils
    {
        
        public static Boolean IsInAscendingById(List<Post> posts) {
            var expectedList = posts.OrderBy(post => post.id);
            return posts.SequenceEqual(expectedList);
        }

        public static Boolean IsEmpty(string text) {
            return text.Equals("");
        }

        public static string GetRandomString() {
            int stringLength = 8;
            string result = "";
            Random random = new Random();
            for (int i = 0; i < stringLength; i++) { 
                result += (char)random.Next(65, 122);
            }
            return result;
        }

        public static bool ArePostsEquals(Post firstObject, Post secondObject) {          
            return firstObject.id.Equals(secondObject.id)
                && firstObject.title.Equals(secondObject.title)
                && firstObject.userId.Equals(secondObject.userId)
                && firstObject.body.Equals(secondObject.body);
        }

        public static bool AreUsersEquals(User firstObject, User secondObject)
        {
            var comparer = new ObjectsComparer.Comparer<User>();
            return comparer.Compare(firstObject, secondObject);
        }
    }
}
