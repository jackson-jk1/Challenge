

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System;
using Challenge.Api.Request.DTOs.Erros;
using Microsoft.Data.Sqlite;

namespace Challenge.Infrastructure.Middwares
{
	public sealed class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";

			var response = new ValidationErrorsDTO();

			if (ex is NullReferenceException)
			{
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
				response.errorMessage = "Recurso não encontrado.";
			}
			else if (ex is SqliteException)
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				response.errorMessage = "Erro ao inserir no banco de dados, verifique os dados";
			}
			else
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				response.errorMessage = "Ocorreu um erro desconhecido. Por favor, tente novamente mais tarde.";
			}

			var result = JsonConvert.SerializeObject(response);
			return context.Response.WriteAsync(result);
		}
	}
}
