namespace Catalog.Dtos
{
    public record ItemDto //Dto é um objeto que representa um objeto de domínio e é usado para transferir dados entre camadas
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
    }
}