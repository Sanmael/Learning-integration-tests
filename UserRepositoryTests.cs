using Infrastructure.Objects;
using Infrastructure.Utils;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TestProjectNunit.Objects;
using TestProjectNunit.Requests;
using TestProjectNunit.Responses;
using static System.Net.WebRequestMethods;

namespace TestProjectNunit
{
    public class UserRepositoryTests
    {

        private FakeData<InsertUserResponse> _insertUserResponseData;
        private FakeData<InsertUserErrorResponse> _insertUserErrorExistinEmailResponseData;
        private FakeData<InsertUserErrorResponse> _insertUserErrorExistingPhoneResponseData;
        private readonly RequestProcessor _requestProcessor = new RequestProcessor("https://localhost:7049");
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _insertUserResponseData = new FakeData<InsertUserResponse>(UserScenarios.InsertUserSuccess);
            _insertUserErrorExistinEmailResponseData = new FakeData<InsertUserErrorResponse>(UserScenarios.InsertUserErrorWhenExistEmail);
            _insertUserErrorExistingPhoneResponseData = new FakeData<InsertUserErrorResponse>(UserScenarios.InsertUserErrorWhenExistPhone);
        }

        [Test]
        public async Task Should_InsertUser_WhenDataIsCorrect()
        {
            UserDTO user1DTO = new UserDTO("your_password", "your_email@example.com", "123-456-7890", "your_nickname", "User");

            var request = await _requestProcessor.ClientRequestAsync(user1DTO);                        
            var user = JsonConvert.DeserializeObject<InsertUserResponse>(request)!;

            Assert.True(_insertUserResponseData.ExpectedObject(user));
        }
        //[Test]
        //public async Task Should_ThrowException_WhenInsertingUserWithExistingEmail()
        //{
        //    UserDTO user1DTO = new UserDTO("senha123", "user2@email.com", "1234567891", "User1");
        //    UserDTO user2DTO = new UserDTO("outraSenha456", "user2@email.com", "987654321", "User2");
            
        //    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };
        //    await client.PostAsJsonAsync("/api/User", user1DTO);

        //    var postResponse2User = await client.PostAsJsonAsync("/api/User", user2DTO);
        //    var responseString = await postResponse2User.Content.ReadAsStringAsync();
        //    var user = JsonConvert.DeserializeObject<InsertUserErrorResponse>(responseString)!;
           
        //    Assert.That(_insertUserErrorExistinEmailResponseData.ExpectedObject(user));
        //}

        //[Test]
        //public async Task Should_ThrowException_WhenInsertingUserWithExistingPhoneNumber()
        //{
        //    UserDTO user1DTO = new UserDTO("senha123", "user3@email.com", "9876543212", "User1");
        //    UserDTO user2DTO = new UserDTO("outraSenha456", "user5@email.com", "9876543212", "User2");

        //    var client = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };
        //    await client.PostAsJsonAsync("/api/User", user1DTO);
        //    var postResponse2User = await client.PostAsJsonAsync("/api/User", user2DTO);
        //    var responseString = await postResponse2User.Content.ReadAsStringAsync();
        //    var user = JsonConvert.DeserializeObject<InsertUserErrorResponse>(responseString)!;

        //    Assert.That(_insertUserErrorExistingPhoneResponseData.ExpectedObject(user));
        //}
    }
}