namespace ApiMayUnitTest24.Modules
{
    public class PostResponseModel
    {
        public class PostCreateModel
        {
            public string name { get; set; }
            public string job { get; set; }
            public string id { get; set; }
            public DateTime createdAt { get; set; }
        }

       
        public class PostNewRequestUser
        {
            public string name { get; set; }
            public string job { get; set; }
        }
    }
}
