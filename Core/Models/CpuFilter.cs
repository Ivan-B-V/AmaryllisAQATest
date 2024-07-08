using Core.Enums;

namespace Core.Models;

public record CpuFilter
{
    public CPUsManufacturers Manufacturer { get; init; }
}
