

using Newtonsoft.Json;

namespace Challenge.Api.Request.DTOs.Erros
{
	public sealed class ValidationErrorsDTO
	{
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string propertyName { get; set; }
		
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string errorMessage { get; set; }
		
	}
}
