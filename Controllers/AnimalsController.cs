using Cw4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw4.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private static AnimalService _animalService = new AnimalService();

    [HttpGet]
    public IEnumerable<Animal> GetAnimals(string orderBy, string sort)
    {
        return _animalService.GetAnimals(orderBy, sort);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animalService.AddAnimal(animal);
        return Ok();
    }

    [HttpPut]
    [Route("{idAnimal}")]
    public IActionResult UpdateAnimal(int idAnimal, Animal animal)
    {
        _animalService.UpdateAnimal(idAnimal, animal);
        return Ok();
    }

    [HttpDelete]
    [Route("{idAnimal}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        _animalService.DeleteAnimal(idAnimal);
        return Ok();
    }
}