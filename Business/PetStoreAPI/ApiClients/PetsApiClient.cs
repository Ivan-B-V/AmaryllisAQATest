using Business.PetStoreAPI.ResponseModels;
using Core.Enums;
using Core.HttpApiClient;
using Core.Utilities;
using System.Net;

namespace Business.PetStoreAPI.ApiClients;

public class PetsApiClient : HttpApiClient
{
    public void GetPetById(Int64 id, out PetResponse? petResponse, out HttpStatusCode statusCode)
    {
        var response = ExecuteGetRequest(PetStoreApiEndpoints.GetPetById(id));
        petResponse = ResponseConverter.JsonToTypedObject<PetResponse>(response);
        statusCode = response.StatusCode;
    }

    public void GetPetsByStatus(PetStatus status, out ICollection<PetResponse> petResponse, out HttpStatusCode statusCode)
    {
        var response = ExecuteGetRequest(PetStoreApiEndpoints.GetPetsByStatus(status));
        var pets = ResponseConverter.JsonToTypedObject<List<PetResponse>>(response);
        petResponse = pets ?? [];
        statusCode = response.StatusCode;
    }

    public void CreatePet(PetResponse pet, out PetResponse? petResponse, out HttpStatusCode statusCode)
    {
        var response = ExecutePostRequest(PetStoreApiEndpoints.CreatePet(), null, pet);
        petResponse = ResponseConverter.JsonToTypedObject<PetResponse>(response);
        statusCode= response.StatusCode;
    }

    public void UpdatePet(PetResponse pet, out PetResponse? petResponse, out HttpStatusCode statusCode)
    {
        var response = ExecutePutRequest(PetStoreApiEndpoints.CreatePet(), null, pet);
        petResponse = ResponseConverter.JsonToTypedObject<PetResponse>(response);
        statusCode = response.StatusCode;
    }

    public void DeletePet(Int64 id, out DeletePetResponse? petResponse, out HttpStatusCode statusCode)
    {
        var response = ExecuteDeleteRequest(PetStoreApiEndpoints.DeletePet(id));
        petResponse = ResponseConverter.JsonToTypedObject<DeletePetResponse>(response);
        statusCode = response.StatusCode;
    }
}
