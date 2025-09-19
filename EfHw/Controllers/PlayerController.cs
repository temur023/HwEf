using EfHw.Dtos;
using EfHw.Services;
using Microsoft.AspNetCore.Mvc;

namespace EfHw.Controllers;
[ApiController]
[Route("[controller]")]
public class PlayerController(IPlayerService playerService):Controller
{
    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        return Ok(playerService.GetAll());
    }

    [HttpGet("get-by-id")]
    public IActionResult GetById(string id)
    {
        return Ok(playerService.GetById(id));
    }

    [HttpPost("Add")]
    [Consumes("multipart/form-data")]
    public IActionResult Add([FromForm] PlayerCreateDto player)
    {
        return Ok(playerService.Add(player));
    }

    [HttpPut("Update")]
    [Consumes("multipart/form-data")]
    public IActionResult Update([FromForm] PlayerCreateDto player)
    {
        return Ok(playerService.Update(player));
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        return Ok(playerService.Delete(id));
    }
}