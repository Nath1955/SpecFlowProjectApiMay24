namespace SpecFlowProjectApiMay24.StepDefinitions
{
    [Binding]
    public class CreateNewUserStepDefinitions : ApiRequest
    {
        string createUserEndpoint;
        CreateNewResponseUserModel actualUserResponse;
        
        [Given(@"I have a new user endpoint")]
        public void GivenIHaveANewUserEndpoint()
        {
            createUserEndpoint = PostNewUserEndpoint;
        }

        [When(@"I request to create a new user with the following body:")]
        public void WhenIRequestToCreateANewUserWithTheFollowingBody(CreateNewRequestUserModel body)
        {
            var payload = new 
            {
                name = body.name,
                job = body.job
            };

            var response = PostRequest<CreateNewResponseUserModel>(createUserEndpoint, payload,  Method.Post);
            actualUserResponse = response.DeserializeData<CreateNewResponseUserModel>();
        }

        [Then(@"the response code for newly created user is (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponse)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedResponse));
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Then(@"the response body include the following:")]
        public void ThenTheResponseBodyIncludeTheFollowing(CreateNewRequestUserModel expectedResponse)
        {
            Assert.That(expectedResponse.name, Is.EqualTo(actualUserResponse.name));
            Assert.That(expectedResponse.job, Is.EqualTo(actualUserResponse.job));
            Assert.That(actualUserResponse.id != null);
            Assert.That(actualUserResponse.createdAt != null);
        }
    }
}
