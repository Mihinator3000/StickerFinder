namespace StickerFinder.Domain.Dto;

public record StickerDto
{
    public string? Name { get; init; }

    public decimal Price { get; init; }
}