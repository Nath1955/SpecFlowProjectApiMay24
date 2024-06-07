namespace ApiMayUnitTest24.TestModule
{
    public class Tests : ApiRequest
    {
        [Test]
        public async Task GetAllUsers()
        {
            var options = new RestClientOptions("https://reqres.in")
            {
                BaseUrl = new Uri("https://reqre.in")
            };
            var client = new RestClient("https://reqres.in");

            var request = new RestRequest("/api/users?page=1", Method.Get);
            RestResponse response = await client.ExecuteAsync<AllGetUsersResponseModel>(request);

            AllGetUsersResponseModel myDeserializedClass
                = JsonConvert.DeserializeObject<AllGetUsersResponseModel>(response.Content);

            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine((int)response.StatusCode);

            Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
            Assert.That((int)response.StatusCode, Is.EqualTo(200));

            Assert.That(myDeserializedClass?.page, Is.EqualTo(1));
            Assert.That(myDeserializedClass?.per_page, Is.EqualTo(6));
            Assert.That(myDeserializedClass?.total, Is.EqualTo(12));
            Assert.That(myDeserializedClass?.total_pages, Is.EqualTo(2));

            Assert.That(myDeserializedClass?.data[0].id, Is.EqualTo(1));
            Assert.That(myDeserializedClass?.data[0].email, Is.EqualTo("george.bluth@reqres.in"));
            Assert.That(myDeserializedClass?.data[0].first_name, Is.EqualTo("George"));
            Assert.That(myDeserializedClass?.data[0].last_name, Is.EqualTo("Bluth"));
            Assert.That(myDeserializedClass?.data[0].avatar, Is.EqualTo("https://reqres.in/img/faces/1-image.jpg"));

            Assert.That(myDeserializedClass?.data[1].id, Is.EqualTo(2));
            Assert.That(myDeserializedClass?.data[1].email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(myDeserializedClass?.data[1].first_name, Is.EqualTo("Janet"));
            Assert.That(myDeserializedClass?.data[1].last_name, Is.EqualTo("Weaver"));
            Assert.That(myDeserializedClass?.data[1].avatar, Is.EqualTo("https://reqres.in/img/faces/2-image.jpg"));

            Assert.That(myDeserializedClass?.support.url, Is.EqualTo("https://reqres.in/#support-heading"));
            Assert.That(myDeserializedClass?.support.text, Is.EqualTo("To keep ReqRes free, contributions towards server costs are appreciated!"));
        }

        [Test]
        public void GetAllUsersNonAsync()
        {
            var options = new RestClientOptions("https://reqres.in")
            {
                BaseUrl = new Uri("https://reqre.in")
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/users?page=1", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        [Test]
        public async Task GetSingleUser()
        {
            var options = new RestClientOptions("https://reqres.in")
            {
                BaseUrl = new Uri("https://reqre.in")
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/users/2", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.StatusCode);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
            Assert.That((int)response.StatusCode == 200);
        }

        [Test]
        public async Task  GetAllUsersUsingApiRequestMethod() 
        {
            var response = await SendRequest(GetAllUsersEndpoint);
            AllGetUsersResponseModel myDeserializedClass
                = JsonConvert.DeserializeObject<AllGetUsersResponseModel>(response.Content!)!; 
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));
            Assert.That(myDeserializedClass?.page, Is.EqualTo(1));
        }

        [Test]
        public void GetAllUsersUsingApiRequestMethod2()
         {
            var res = GetRequest<AllGetUsersResponseModel>(GetAllUsersEndpoint)
                .DeserializeData<AllGetUsersResponseModel>();

            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));

            Assert.That(res?.page, Is.EqualTo(1));
            Assert.That(res?.per_page, Is.EqualTo(6));
            Assert.That(res?.total, Is.EqualTo(12));
            Assert.That(res?.total_pages, Is.EqualTo(2));
                        
            Assert.That(res?.data[0].id, Is.EqualTo(1));
            Assert.That(res?.data[0].email, Is.EqualTo("george.bluth@reqres.in"));
            Assert.That(res?.data[0].first_name, Is.EqualTo("George"));
            Assert.That(res?.data[0].last_name, Is.EqualTo("Bluth"));
            Assert.That(res?.data[0].avatar, Is.EqualTo("https://reqres.in/img/faces/1-image.jpg"));
                        
            Assert.That(res?.data[1].id, Is.EqualTo(2));
            Assert.That(res?.data[1].email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(res?.data[1].first_name, Is.EqualTo("Janet"));
            Assert.That(res?.data[1].last_name, Is.EqualTo("Weaver"));
            Assert.That(res?.data[1].avatar, Is.EqualTo("https://reqres.in/img/faces/2-image.jpg"));
                        
            Assert.That(res?.support.url, Is.EqualTo("https://reqres.in/#support-heading"));
            Assert.That(res?.support.text, Is.EqualTo("To keep ReqRes free, contributions towards server costs are appreciated!"));
        }

        [Test]
        public void GetSingleUsersUsingApiRequestMethod()
        {
            var res = GetRequest<SingleGetUserResponseModel>(GetSingleUsersEndpoint)
                .DeserializeData<SingleGetUserResponseModel>();
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("OK"));

            Assert.That(res?.data.id, Is.EqualTo(2));
            Assert.That(res?.data.email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(res?.data.first_name, Is.EqualTo("Janet"));
            Assert.That(res?.data.last_name, Is.EqualTo("Weaver"));
            Assert.That(res?.data.avatar, Is.EqualTo("https://reqres.in/img/faces/2-image.jpg"));
            Assert.That(res?.support.url, Is.EqualTo("https://reqres.in/#support-heading"));
            Assert.That(res?.support.text, Is.EqualTo("To keep ReqRes free, contributions towards server costs are appreciated!"));
        }

        [Test]
        public async Task GetSingleUserNotFoundApiRequestMethod()
        {
            var res = await SendRequest(GetSingleUserNotFoundEndpoint);
            Assert.That(response.StatusCode.ToString(), Is.EqualTo("NotFound"));
            Assert.That((int)response.StatusCode, Is.EqualTo(404));
        }
    }
}