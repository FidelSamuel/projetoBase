using FluentAssertions;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Domain.Test
{
    public class ProductUnitTestBase
    {
        #region Casos de teste Positivos
        [Fact(DisplayName = "Product no present ID parameter.")]
        public void CreateProduct_IdParameterLess_ResultValid()
        {
            Action action = () => new Product("Product test", "description test", 10, 10, "imagem.test");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Product parameters is not null.")]
        public void CreateProduct_WithValidParameters_ResultValid()
        {
            Action action = () => new Product(1, "Product test", "description test", 10, 10, "https://via.placeholder.com/150");
            action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Casos de teste Negativos 
        [Fact(DisplayName = "ID negative exception.")]
        public void CreateProduct_NegativeParametersId_ResultException()
        {
            Action action = () => new Product(-1, "Product test", "description test", 10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid negative values for id.");
        }

        [Fact(DisplayName = "Name in Product is null.")]
        public void CreateProduct_NameParameterNull_ResultException()
        {
            Action action = () => new Product(1, null, "description test", 10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Name short in Product.")]
        public void CreateProduct_NameParameterShort_ResultException()
        {
            Action action = () => new Product(1, "Pr", "description test", 10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid short names, minimum 3 characteres.");
        }

        [Fact(DisplayName = "Description in Product is null.")]
        public void CreateProduct_DescriptionParameterNull_ResultException()
        {
            Action action = () => new Product(1, "Product test", null, 10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Description short in Product.")]
        public void CreateProduct_DescriptionParameterShort_ResultException()
        {
            Action action = () => new Product(1, "Product test", "Desc", 10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid short descriptions, minimum 5 characters.");
        }

        [Fact(DisplayName = "Price negative exception.")]
        public void CreateProduct_NegativeParametersPrice_ResultException()
        {
            Action action = () => new Product(1, "Product test", "description test", -10, 10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid negative values for price.");
        }

        [Fact(DisplayName = "Stock negative exception.")]
        public void CreateProduct_NegativeParametersStock_ResultException()
        {
            Action action = () => new Product(1, "Product test", "description test", 10, -10, "https://via.placeholder.com/150");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid negative values for stock.");
        }

        [Fact(DisplayName = "Image long URL exception.")]
        public void CreateProduct_LongParametersUrl_ResultException()
        {
            Action action = () => new Product(1, "Product test", "description test", 10, 10, "https://www.google.com/search?q=imagem+gato&&tbm=isch&ved=2ahUKEwiS0sPzzJuCAxUvkZUCHUfvDsIQ2-cCegQIABAA&oq=imagem+gato&gs_lcp=CgNpbWcQAzIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQ6BAgjECc6CAgAEIAEELEDOgcIABCKBRBDOgoIABCKBRCxAxBDUKIEWM8OYMUQaABwAHgAgAFtiAHwBJIBAzEuNZgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=BX4-ZdK7JK-i1sQPx967kAw&bih=730&biw=1536#imgrc=dWk-HsJ50D5YMM");
            action.Should().Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid long URL, maximum 250 characteres.");
        }
        #endregion
    }
}

