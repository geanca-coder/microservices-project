using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using play.catalog.service.Dtos;
using System;

namespace play.catalog.service.Controllers
{
    //https:localhost:5001/items
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new(){
            new ItemDto(Guid.NewGuid(),"Potion", "Restores an small amount of HP",5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"Antidote", "Restores an small amount of HP",3, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(),"sword", "Restores an small amount of HP",4, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get(){
            return items;
        }


        [HttpGet("{id}")]        
        public ActionResult<ItemDto> GetById(Guid id){
            var item = items.Where(item => item.id ==id).SingleOrDefault();
            if (item == null){
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult <ItemDto> post(createItemDto createItemDto1 )
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto1.name, createItemDto1.description, createItemDto1.price, DateTimeOffset.UtcNow);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id = item.id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, updatedItemDto updatedItemDt){
            var existingItem = items.Where(item => item.id == id).SingleOrDefault();

            if (existingItem == null){
                return NotFound();

            }
            var updatedItem = existingItem with{
                name = updatedItemDt.name,
                description = updatedItemDt.description,
                price = updatedItemDt.price
            };

            var index = items.FindIndex(existingItem => existingItem.id == id);

            items[index] = updatedItem;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult delete(Guid id ){
            var index = items.FindIndex(existingItem => existingItem.id == id );
            
            if (index < 0){
                return NotFound();
            }
            items.RemoveAt(index);
            return NoContent();
        }
    }
}