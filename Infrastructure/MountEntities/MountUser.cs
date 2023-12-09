using Infrastructure.EntitiesObjects;
using Infrastructure.EntitiesObjects.Cenarios;
using Infrastructure.EntitiesObjects.Requests;
using Infrastructure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MountEntities
{
    public class MountUser
    {
        public static UserRequest MountInsertUserSuccessRequest()
        {
            string a = "teste";
            UserRequest userRequest = GetData.CreateInstanceRequest<UserRequest>(UserCenarios.InsertUserSuccess);
            userRequest.Method = EndPointsMethods.InsertUserApi;

            return userRequest;
        }
        public static List<UserRequest> MountInsertUserErrorWhenExistEmailRequest()
        {
            List<UserRequest> userRequests = GetData.CreateInstancesRequests<UserRequest>(UserCenarios.InsertUserErrorWhenExistEmail);
            userRequests.ForEach(x => x.Method = EndPointsMethods.InsertUserApi);

            return userRequests;
        }
        public static List<UserRequest> MountInsertUserErrorWhenExistPhoneRequest()
        {
            List<UserRequest> userRequests = GetData.CreateInstancesRequests<UserRequest>(UserCenarios.InsertUserErrorWhenExistPhone);
            userRequests.ForEach(x => x.Method = EndPointsMethods.InsertUserApi);

            return userRequests;
        }
    }
}
