using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TestApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestController : ControllerBase
	{
		private readonly ILogger<TestController> _logger;

		public TestController(ILogger<TestController> logger)
		{
			_logger = logger;
		}

		[HttpGet("Get", Name = "GetIt")]
		public MyType Get()
		{
			return new MyType();
		}

		[HttpPost("PostRequired", Name = "PostRequired")]
		public void BodyPostRequired([FromBody, Required] MyType asd)
		{
		}

		[HttpPost("PostNonRequired", Name = "PostNotRequired")]
		public void BodyPost([FromBody] MyType asd)
		{
		}
	}

	public class MyType
	{
		[Required]
		public string RequiredString { get; set; }

		public string NonRequiredString { get; set; }

		[Required]
		public int RequiredInteger { get; set; }

		public int NonRequiredInteger { get; set; }

		[Required]
		public MyInnerType RequiredInner { get; set; }

		public MyInnerType NonRequiredInner { get; set; }
	}


	public class MyInnerType
	{
		public int IgnoreMe { get; set; }
	}
}
