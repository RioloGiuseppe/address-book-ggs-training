namespace address_book_ggs_training.Entities
{
    public interface ITypedId
    {
        string Number { get; set; }
        string Type { get; set; }
    }
}