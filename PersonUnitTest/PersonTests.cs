using ExpectedObjects;
using Infrastructure.EntitiesObjects;
using Infrastructure.EntitiesObjects.Cenarios;
using Infrastructure.EntitiesObjects.Requests;
using Infrastructure.EntitiesObjects.Responses;
using Infrastructure.MountEntities;
using Infrastructure.Objects;
using Infrastructure.Utils;
using Newtonsoft.Json;


using System.Net.Http.Json;

namespace PersonIntegrationTests
{
    public class PersonTests
    {
        private readonly FakeData<PersonResponse> _insert;
        private readonly RequestProcessor _requestProcessor = new RequestProcessor(EndPoints.PersonApiUrl);

        public PersonTests()
        {
            string a = "teste";

            _insert = new FakeData<PersonResponse>(PersonCenarios.InsertPersonSuccess);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task InsertPersonAsync()
        {
            _insert.IgnoreProperty(x => x.Id);

            PersonRequest personRequest = new MountPerson().MountInsertPersonSuccessRequest();

            string response = await _requestProcessor.ClientRequestAsync(personRequest);

            var personInsert = JsonConvert.DeserializeObject<PersonResponse>(response)!;

            Assert.IsTrue(_insert.ExpectedObject(personInsert));
        }
        //[Test]

        //public async Task GetPersonByIdAsync()
        //{
        //    _get.IgnoreProperty(X => X.PersonDTO.id).IgnoreProperty(x => x.PersonDTO.BirthDate);

        //    GetPersonByIdRequest getPersonByIdRequest = new GetPersonByIdRequest(1898697110);

        //    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7129") };

        //    var postResponse = await client.GetAsync($"/api/Person?personId={getPersonByIdRequest.id}");

        //    var responseString = await postResponse.Content.ReadAsStringAsync();

        //    var personGet = JsonConvert.DeserializeObject<GetPersonByIdResponse>(responseString)!;

        //    Assert.True(_get.ExpectedObject(personGet));
        //}
    }
}