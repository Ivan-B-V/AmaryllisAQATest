using Business.PetStoreAPI.ResponseModels;
using Core.Enums;

namespace Tests.APITests;

public class PetTestData
{
    public static IEnumerable<(PetResponse, bool)> TestCases()
    {
        //pet with Id in range from 0 to Int64.Max
        yield return (new PetResponse()
        {
            Id = 529,
            Name = "TestPet",
            Status = PetStatus.pending,
            Category = new Category
            {
                Id = 123,
                Name = "NewCategory"
            },
            Tags =
            [
                new() { Id = 1234, Name = "BestPet " }
            ]
        }, true);

        // pet with Id in out of range from 0 to Int64.Max
        yield return (new PetResponse()
        {
            Id = -2,
            Name = "TestPet",
            Status = PetStatus.pending,
            Category = new Category
            {
                Id = 123,
                Name = "NewCategory"
            },
            Tags =
            [
                new() { Id = 1234, Name = "BestPet " }
            ]
        }, false);

        // pet with Id Int64.Max
        yield return (new PetResponse()
        {
            Id = Int64.MaxValue,
            Name = "TestPet",
            Status = PetStatus.pending,
            Category = new Category
            {
                Id = 123,
                Name = "NewCategory"
            },
            Tags =
            [
                new() { Id = 1234, Name = "BestPet " }
            ]
        }, true);
    }
}