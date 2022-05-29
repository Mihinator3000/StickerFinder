namespace StickerFinder.Domain.Dto;

public record WeaponDto
{
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public string? Link { get; init; }
}