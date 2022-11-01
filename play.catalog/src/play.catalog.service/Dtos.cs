using System;
using System.ComponentModel.DataAnnotations;


namespace play.catalog.service.Dtos
{
    public record ItemDto(Guid id, string name, string description, decimal price, DateTimeOffset createdDate);

    public record createItemDto([Required] string name, string description, [Range(0,1000)] decimal price);

    public record updatedItemDto([Required] string name, string description, [Range(0,1000)] decimal price);
    
}