using Core.Enums;

namespace Business.PetStoreAPI.ResponseModels;

public record Category
{
    public Int64 Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public record PetResponse
{
    public Int64 Id { get; set; }
    public Category? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> PhotoUrls { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public PetStatus Status { get; set; }
}

public record Tag
{
    public Int64 Id { get; set; }
    public string Name { get; set; } = string.Empty;
}