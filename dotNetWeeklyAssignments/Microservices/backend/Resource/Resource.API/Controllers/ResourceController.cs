using Microsoft.AspNetCore.Mvc;
using Resource.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Resource.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ResourceController : ControllerBase
{
    private static List<StudyResource> _resources = new();

    [HttpPost]
    public IActionResult UploadResource(StudyResource resource)
    {
        resource.Id = _resources.Count + 1;
        _resources.Add(resource);
        return Ok(resource);
    }

    [HttpGet]
    public IActionResult GetResources()
    {
        return Ok(_resources);
    }
}
