using System.Net;

namespace Business.PetStoreAPI.ResponseModels;

public record DeletePetResponse
{
    public HttpStatusCode Code { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
}
