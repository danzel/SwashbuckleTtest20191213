using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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

		[HttpGet]
		public MyType Get()
		{
			return new MyType
			{
				Stringy = "a string",
				Integer = 1009,
				MyEnumValue = MyEnum.Value2
			};
		}
	}

	public class MyType
	{
		[Required]
		public string Stringy { get; set; }

		public int Integer { get; set; }

		public MyEnum MyEnumValue { get; set; }
	}

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum MyEnum
	{
		Value1 = 1,
		Value2 = 2
	}
}
