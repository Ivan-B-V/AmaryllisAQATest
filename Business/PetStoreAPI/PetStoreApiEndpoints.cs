using Core.Enums;

namespace Business.PetStoreAPI;

public static class PetStoreApiEndpoints
{
    #region PetEndpoints
    public static string GetPetById(Int64 id) => $"pet/{id}";
    public static string GetPetsByStatus(PetStatus status) => $"pet/findByStatus?status={status}";
    public static string CreatePet() => "pet/";
    public static string DeletePet(Int64 id) => $"pet/{id}";
    #endregion
}
