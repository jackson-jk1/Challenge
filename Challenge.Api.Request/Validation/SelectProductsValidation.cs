
using Challenge.Api.Request.DTOs;
using FluentValidation;


namespace Challenge.Api.Request.Validation
{
	public sealed class SelectProductsValidation: AbstractValidator<ProductFilterDTO>
	{
		public SelectProductsValidation()
		{

			RuleFor(product => product.Description).NotEmpty().When(product => product.Description != null)
				.WithMessage("A descrição do produto é obrigatória.");

			RuleFor(product => product.IsActive)
				.NotNull().WithMessage("A situação do produto é obrigatória.")
				.When(product => product.IsActive.HasValue);

			RuleFor(product => product.ManufactureDateStart)
				.NotNull().WithMessage("A data de início da fabricação é obrigatória.")
				.When(product => product.ManufactureDateEnd.HasValue);

			RuleFor(product => product.ManufactureDateEnd)
				.NotNull().WithMessage("A data de término da fabricação é obrigatória.")
				.When(product => product.ManufactureDateStart.HasValue);

			RuleFor(product => product.ExpiryDateStart)
				.NotNull().WithMessage("A data de início da validade é obrigatória.")
				.When(product => product.ExpiryDateEnd.HasValue);

			RuleFor(product => product.ExpiryDateEnd)
				.NotNull().WithMessage("A data de término da validade é obrigatória.")
				.When(product => product.ExpiryDateStart.HasValue);

			RuleFor(product => product.SupplierCNPJ).NotEmpty().WithMessage("O CNPJ do fornecedor é obrigatório deve ser preenchido ou enviado vazio.")
				.When(product => !string.IsNullOrEmpty(product.SupplierCNPJ))
				.Matches("^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$")
				.WithMessage("O CNPJ do fornecedor deve estar no formato XX.XXX.XXX/XXXX-XX.");

			RuleFor(product => new { product.ManufactureDateStart, product.ManufactureDateEnd })
				.Must(dates => dates.ManufactureDateEnd > dates.ManufactureDateStart)
				.WithMessage("A data de término da fabricação deve ser posterior à data de início da fabricação.")
				.When(product => product.ManufactureDateStart.HasValue && product.ManufactureDateEnd.HasValue);

			RuleFor(product => new { product.ExpiryDateStart, product.ExpiryDateEnd })
				.Must(dates => dates.ExpiryDateEnd > dates.ExpiryDateStart)
				.WithMessage("A data de término da validade deve ser posterior à data de início da validade.")
				.When(product => product.ExpiryDateStart.HasValue && product.ExpiryDateEnd.HasValue);


		}
	}
}
