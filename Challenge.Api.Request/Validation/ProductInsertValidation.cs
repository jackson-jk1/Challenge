
using Challenge.Api.Request.DTOs;
using FluentValidation;


namespace Challenge.Api.Request.Validation
{
	public sealed class ProductInsertValidation : AbstractValidator<ProductInsertDTO>
	{
		public ProductInsertValidation()
		{


			RuleFor(product => product.Description).NotEmpty().WithMessage("A descrição do produto é obrigatória.");

			RuleFor(product => product.IsActive).NotNull().WithMessage("A situação do produto é obrigatória.");


			RuleFor(product => product.ManufactureDate).NotNull().WithMessage("A data de fabricação é obrigatória.");


			RuleFor(product => product.ExpiryDate).NotNull().WithMessage("A data de validade é obrigatória.");


			RuleFor(product => product.SupplierCode).NotEmpty().WithMessage("O código do fornecedor deve ser preenchido ou enviado vazio");

			
			RuleFor(product => product.SupplierDescription).NotEmpty().WithMessage("A descrição do fornecedor  deve ser preenchida ou enviado vazia");
		


			RuleFor(product => product.SupplierCNPJ).NotEmpty().WithMessage("O CNPJ do fornecedor é obrigatório deve ser preenchido ou enviado vazio.")
				.When(product => !string.IsNullOrEmpty(product.SupplierCNPJ))
				.Matches("^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$")
				.WithMessage("O CNPJ do fornecedor deve estar no formato XX.XXX.XXX/XXXX-XX.");

			RuleFor(product => product.ManufactureDate)
				.LessThan(product => product.ExpiryDate)
				.WithMessage("A data de fabricação deve ser anterior à data de validade.")
				.When(product => product.ManufactureDate.HasValue && product.ExpiryDate.HasValue);

			RuleFor(product => product.ExpiryDate)
				.GreaterThan(product => product.ManufactureDate)
				.WithMessage("A data de validade deve ser posterior à data de fabricação.")
				.When(product => product.ManufactureDate.HasValue && product.ExpiryDate.HasValue);



		}
	}
}
