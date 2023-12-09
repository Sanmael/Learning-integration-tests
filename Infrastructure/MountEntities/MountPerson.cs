using Infrastructure.EntitiesObjects;
using Infrastructure.EntitiesObjects.Cenarios;
using Infrastructure.EntitiesObjects.Requests;
using Infrastructure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MountEntities
{
    public class MountPerson
    {
        public PersonRequest MountInsertPersonSuccessRequest()
        {
            PersonRequest personRequest = GetData.CreateInstanceRequest<PersonRequest>(PersonCenarios.InsertPersonSuccess);
            personRequest.Method = EndPointsMethods.InsertPersonApi;

            return personRequest;
        }
    }
}
