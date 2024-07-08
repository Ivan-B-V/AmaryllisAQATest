using Business.PetStoreAPI.ApiClients;
using Business.PetStoreAPI.ResponseModels;
using NUnit.Framework;
using System.Net;

namespace Tests.APITests;

[TestFixture]
public class CreatePetTests
{
    private readonly PetsApiClient client = new();
    private Int64 createdPetId = 0;

    [Test]
    [TestCaseSource(typeof(PetTestData), nameof(PetTestData.TestCases))]
    public void CreatePetTest((PetResponse pet, bool expectedResult) testData)
    {
        client.CreatePet(testData.pet, out PetResponse? createPetResponse, out HttpStatusCode createStatusCode);
        createdPetId = createPetResponse.Id;
        Assert.Multiple(() =>
        {
            Assert.That(createStatusCode.Equals(HttpStatusCode.OK), $"Create failed. Code: {createStatusCode}.");
            Assert.That(testData.pet.Id.Equals(createPetResponse?.Id), Is.EqualTo(testData.expectedResult), $"Different ids. Expected: {testData.pet.Id}, actual: {createPetResponse?.Id}");
        });
    }

    [TearDown]
    public void TearDown()
    {
        client.DeletePet(createdPetId, out DeletePetResponse? deleteResponse, out HttpStatusCode deleteStatusCode);
    }
}