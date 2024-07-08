using Business.PetStoreAPI.ApiClients;
using Business.PetStoreAPI.ResponseModels;
using Core.Enums;
using NUnit.Framework;
using System.Net;

namespace Tests.APITests;

[TestFixture]
public class PetApiTests
{
    private readonly PetsApiClient client = new();
    private PetResponse createdTestPet;

    [SetUp]
    public void SetUp()
    {
        PetResponse newPet = new()
        {
            Id = 556,
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
        };

        client.CreatePet(newPet, out PetResponse? createResponse, out HttpStatusCode createStatusCode);
        createdTestPet = createResponse;
    }

    [TearDown]
    public void TearDown()
    {
        client.DeletePet(createdTestPet.Id, out DeletePetResponse? deleteResponse, out HttpStatusCode deleteStatusCode);
    }

    [Test]
    public void CreatePetTest()
    {
        PetResponse newPet = new()
        {
            Id = 556,
            Name = "TestPet",
            Status = PetStatus.pending
        };

        client.CreatePet(newPet, out PetResponse? createPetResponse, out HttpStatusCode createStatusCode);

        Assert.Multiple(() =>
        {
            Assert.That(createStatusCode.Equals(HttpStatusCode.OK), $"Create failed. Code: {createStatusCode}.");
            Assert.That(newPet.Id.Equals(createPetResponse?.Id), $"Different ids. Expected: {newPet.Id}, actual: {createPetResponse?.Id}");
        });
    }

    [Test]
    public void GetPetByIdTest()
    {
        client.GetPetById(556, out PetResponse? getPetResponse, out HttpStatusCode getStatusCode);

        Assert.Multiple(() =>
        {
            Assert.That(getStatusCode.Equals(HttpStatusCode.OK), $"Get failed. Code: {getStatusCode}.");
            Assert.That(createdTestPet.Id.Equals(getPetResponse?.Id), $"Different ids. Expected: {createdTestPet.Id}, actual: {getPetResponse?.Id}");
        });
        
    }

    [Test]
    [TestCase(PetStatus.pending)]
    public void GetPetsByStatusTest(PetStatus petStatus)
    {
        client.GetPetsByStatus(petStatus, out ICollection<PetResponse>? petResponseModels, out HttpStatusCode statusCode);

        Assert.Multiple(() => 
        {
            Assert.That(statusCode.Equals(HttpStatusCode.OK));
            Assert.That(petResponseModels.All(pet => pet.Status.Equals(petStatus)), $"Not all pets has status: {statusCode}");
        });
    }

    [Test]
    public void UpdatePetTest()
    {
        var updatedPet = createdTestPet with { Name = "Updated" };

        client.UpdatePet(createdTestPet, out PetResponse? response, out HttpStatusCode statusCode);

        Assert.That(response is not null);
    }

    [Test]
    public void DeletePetTest()
    {
        client.DeletePet(createdTestPet.Id, out DeletePetResponse? deleteResponse, out HttpStatusCode deleteStatusCode);
        
        Assert.Multiple(() => 
        {
            Assert.That(deleteStatusCode.Equals(HttpStatusCode.OK), $"Delete response code is {deleteStatusCode}. Message: {deleteResponse?.Message}");
            Assert.That(createdTestPet.Id.Equals(Int64.Parse(deleteResponse.Message)));
        });
    }
}