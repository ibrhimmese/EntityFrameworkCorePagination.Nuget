namespace RepositoryAndPaging;

public interface IEntity<T>
{
    T Id { get; set; }
}
