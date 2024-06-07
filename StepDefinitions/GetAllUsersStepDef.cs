namespace SpecFlowProjectApiMay24.StepDefinitions
{
    [Binding]
    public sealed class GetAllUsersStepDef : ApiRequest
    {
        string getAllUsersEndPoint;
        AllGetUsersResponseModel actual;

        [Given(@"I have a resource")]
        public void GivenIHaveAResource()
        {
            getAllUsersEndPoint = GetAllUsersEndpoint;
        }

        [When(@"I request all users info")]
        public void WhenIRequestAllUsersInfo() 
        {
           var response = GetRequest<AllGetUsersResponseModel>(getAllUsersEndPoint, RestSharp.Method.Get);
           actual = response.DeserializeData<AllGetUsersResponseModel>();
        }

        [Then(@"the response code to retrieve all users (.*)")]
        public void ThenTheResponseCodeIs(int expectedResponse)
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedResponse));
        }

        [Then(@"the response body includes the following:")]
        public void ThenTheResponseBodyIncludesTheFollowing(IEnumerable<TableModel> expected)
        {

            Assert.That(actual?.page, Is.EqualTo(expected.First().page));
            Assert.That(actual?.per_page, Is.EqualTo(expected.First().per_page));
            Assert.That(actual?.total, Is.EqualTo(expected.First().total));
            Assert.That(actual.total_pages, Is.EqualTo(expected.First().total_pages));
                        
            Assert.That(actual?.data[0].id, Is.EqualTo(expected.First().id));
            Assert.That(actual?.data[0].email, Is.EqualTo(expected.First().email));
            Assert.That(actual?.data[0].first_name, Is.EqualTo(expected.First().first_name));
            Assert.That(actual?.data[0].last_name, Is.EqualTo(expected.First().last_name));
            Assert.That(actual?.data[0].avatar, Is.EqualTo(expected.First().avatar));

            Assert.That(actual?.data[1].id, Is.EqualTo(expected.Last().id));
            Assert.That(actual?.data[1].email, Is.EqualTo(expected.Last().email));
            Assert.That(actual?.data[1].first_name, Is.EqualTo(expected.Last().first_name));
            Assert.That(actual?.data[1].last_name, Is.EqualTo(expected.Last().last_name));
            Assert.That(actual?.data[1].avatar, Is.EqualTo(expected.Last().avatar));
        }               
    }
}
