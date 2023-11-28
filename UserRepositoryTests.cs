using Infrastructure.Objects;
using Newtonsoft.Json;
using System.Net.Http.Json;
using TestProjectNunit.Requests;
using TestProjectNunit.Responses;

namespace TestProjectNunit
{
    public class UserRepositoryTests
    {

        private readonly FakeData<InsertUserResponse> _fakeData;
        public UserRepositoryTests()
        {
            _fakeData = new FakeData<InsertUserResponse>().Init();            
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        [Test, Order(1)]
        public async Task Should_InsertUser_WhenDataIsCorrect()
        {            
            // Arrange
            UserDTO user1DTO = new UserDTO("your_password", "your_email@example.com", "123-456-7890", "your_nickname");
            // Act
            var client = new HttpClient { BaseAddress = new Uri("https://localhost:7049") };

            var postResponse = await client.PostAsJsonAsync("/api/User", user1DTO);            

            var responseString = await postResponse.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<InsertUserResponse>(responseString)!;

            // Assert
            Assert.True(_fakeData.ExpectedObject(user));

        }
        //[Test, Order(2)]
        //public async Task Should_ThrowException_WhenInsertingUserWithExistingEmail()
        //{
        //    // Arrange
        //    UserDTO user1DTO = new UserDTO("senha123", "user2@email.com", "1234567891", "User1");
        //    UserDTO user2DTO = new UserDTO("outraSenha456", "user2@email.com", "987654321", "User2");

        //    // Act
        //    await _userService.InsertUser(user1DTO);

        //    // Assert
        //    var ex = Assert.ThrowsAsync<TaskApplicatioException>(() => _userService.InsertUser(user2DTO));
        //    Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.EmailAlreadyExists));
        //}

        //[Test, Order(3)]
        //public async Task Should_ThrowException_WhenInsertingUserWithExistingPhoneNumber()
        //{
        //    // Arrange
        //    UserDTO user1DTO = new UserDTO("senha123", "user23@email.com", "123456789", "User1");
        //    UserDTO user2DTO = new UserDTO("outraSenha456", "user25@email.com", "123456789", "User2");

        //    // Act
        //    await _userService.InsertUser(user1DTO);

        //    // Assert
        //    var ex = Assert.ThrowsAsync<TaskApplicatioException>(() => _userService.InsertUser(user2DTO));
        //    Assert.That(ex.Message, Is.EqualTo(ExceptionMessages.PhoneAlreadyExists));
        //}
    }
}