namespace ApiMayUnitTest24.Modules
{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Datum
        {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

        public class AllGetUsersResponseModel
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<Datum> data { get; set; }
            public Support support { get; set; }
        }

        public class SingleGetUserResponseModel
        {
            public Datum data { get; set; }
            public Support support { get; set; }
        }

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }

}
