namespace Catalog.Entities
{
    public record Item //propriedade record é usada para garantir a imutabilidade da entidade
    {
        public Guid Id { get; init; } //Guid é um tipo de dado que gera um identificador único para cada entidade
        public string Name { get; init; } 
        public decimal Price { get; init; } //propriedade init é usada para garantir a imutabilidade da entidade
        public DateTimeOffset CreatedDate { get; init; }
    }
}
