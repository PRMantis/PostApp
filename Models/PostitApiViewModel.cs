
namespace PostApp.Models
{
    public class PostitApiModel
    {
        public bool success { get; set; }
        public RequestData[] data { get; set; }

        public class RequestData
        {
            public string post_code { get; set; }
        }
    }
}