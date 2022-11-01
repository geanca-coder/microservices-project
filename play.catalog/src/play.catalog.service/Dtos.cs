using System;

namespace play.catalog.service.Dtos
{
    public record ItemDto(Guid id, string name, string description, decimal price, DateTimeOffset createdDate);

    public record createItemDto(string name, string description, decimal price);

    public record updatedItemDto(string name, string description, decimal price);
    
}