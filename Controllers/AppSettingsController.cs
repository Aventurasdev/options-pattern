using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Options.Controllers;

[ApiController]
[Route("[controller]")]
public class AppSettingsController : ControllerBase
{
    private readonly ApplicationSettings _iOptions;
    private readonly IOptionsMonitor<ApplicationSettings> _iOptionsMonitor;
    private readonly IOptionsSnapshot<ApplicationSettings> _iOptionsSnapshot;

    public AppSettingsController(IOptions<ApplicationSettings> options, IOptionsMonitor<ApplicationSettings> iOptionsMonitor, IOptionsSnapshot<ApplicationSettings> optionsSnapshot)
    {
        _iOptions = options.Value;
        _iOptionsMonitor = iOptionsMonitor;
        _iOptionsSnapshot = optionsSnapshot;
    }

    [HttpGet("GetOptions")]
    public IActionResult GetOptions()
    {
        return Ok(_iOptions);
    }

    [HttpGet("GetOptionsSnapshot")]
    public IActionResult GetOptionsSnapshot()
    {
        return Ok(_iOptionsSnapshot.Value);
    }

    [HttpGet("GetOptionsMonitor")]
    public IActionResult GetOptionsMonitor()
    {
        return Ok(_iOptionsMonitor.CurrentValue);
    }
}