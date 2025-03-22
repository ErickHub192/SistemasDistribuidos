using HobbiesApi.Services;
using Microsoft.AspNetCore.Mvc;
using HobbiesApi.Infrastructure.Soap.Dtos;
namespace HobbiesApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HobbiesController : ControllerBase
{
    private readonly IHobbiesService _hobbiesService;

    public HobbiesController(IHobbiesService hobbiesService)
    {
        _hobbiesService = hobbiesService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HobbiesResponseDto>> GetHobbyById(Guid id, CancellationToken cancellationToken)
    {
        var hobby = await _hobbiesService.GetHobbyById(id, cancellationToken);
        if (hobby is null)
        {
            return NotFound();
        }
        return Ok(hobby);
    }

    [HttpGet]
    public async Task<ActionResult<List<HobbiesResponseDto>>> GetHobbyByName([FromQuery] string name, CancellationToken cancellationToken)
    {
        var hobbies = await _hobbiesService.GetHobbyByName(name, cancellationToken);

        if (hobbies == null || !hobbies.Any())
        {
            return NotFound();
        }

        return Ok(hobbies);
    }
    }
