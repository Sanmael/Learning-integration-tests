using Infrastructure.EntitiesObjects;
using Infrastructure.EntitiesObjects.Cenarios;
using Infrastructure.EntitiesObjects.Requests;
using Infrastructure.EntitiesObjects.Responses;
using Infrastructure.MountEntities;
using Infrastructure.Objects;
using Infrastructure.Utils;
using Newtonsoft.Json;

namespace UserIntegrationTests
{
    public class UserRepositoryTests
    {
        private const int FirstItemInList = 1;
        private FakeData<UserResponse> _insertUserResponseData;                
        private FakeData<UserResponse> _insertUserResponseInsertUserErrorWhenExistEmailData;                
        private FakeData<UserResponse> _insertUserResponseInsertUserErrorWhenExistPhoneData;                
        private readonly RequestProcessor _requestProcessor = new RequestProcessor(EndPoints.UserApiUrl);
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _insertUserResponseData = new FakeData<UserResponse>(UserCenarios.InsertUserSuccess);
            _insertUserResponseInsertUserErrorWhenExistEmailData = new FakeData<UserResponse>(UserCenarios.InsertUserErrorWhenExistEmail);
            _insertUserResponseInsertUserErrorWhenExistPhoneData = new FakeData<UserResponse>(UserCenarios.InsertUserErrorWhenExistPhone);                        
        }

        [Test]        
        public async Task Should_InsertUser_WhenDataIsCorrect()
        {
            _insertUserResponseData.IgnoreProperty(x => x.UserDTO.Id);
            UserRequest userRequest = MountUser.MountInsertUserSuccessRequest();

            var request = await _requestProcessor.ClientRequestAsync(userRequest);                        
            var user = JsonConvert.DeserializeObject<UserResponse>(request)!;

            Assert.True(_insertUserResponseData.ExpectedObject(user));
        }
        [Test]
        public async Task Should_ThrowException_WhenInsertingUserWithExistingEmail()
        {
            _insertUserResponseInsertUserErrorWhenExistEmailData.IgnoreProperty(x => x.UserDTO);
            List<UserRequest> userRequests = MountUser.MountInsertUserErrorWhenExistEmailRequest();
            await _requestProcessor.ClientRequestAsync(userRequests.First());

            string error = await _requestProcessor.ClientRequestAsync(userRequests.Skip(FirstItemInList).First());
            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(error)!;

            Assert.True(_insertUserResponseInsertUserErrorWhenExistEmailData.ExpectedObject(user));
        }
        [Test]
        public async Task Should_ThrowException_WhenInsertingUserWithExistingPhoneNumber()
        {
            _insertUserResponseInsertUserErrorWhenExistPhoneData.IgnoreProperty(x => x.UserDTO);
            List<UserRequest> userRequests = MountUser.MountInsertUserErrorWhenExistEmailRequest();
            await _requestProcessor.ClientRequestAsync(userRequests[0]);

            string error = await _requestProcessor.ClientRequestAsync(userRequests[1]);
            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(error)!;

            Assert.True(_insertUserResponseInsertUserErrorWhenExistEmailData.ExpectedObject(user));
        }
    }
}