using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto //record é uma classe imutável
    {
        //id é gerado automaticamente

        [Required] //atributo que indica que o campo é obrigatório
        public string Name { get; init; }

        [Required]
        [Range(1, 1000)]
        public decimal Price { get; init; }

        //DateTimeOffset é gerado automaticamente
    }
}
