# Dependency
 Created .net8

## Install
 Kurulum için bu kodu kullanın

 ```Csharp
 public sealed class Example:Entity<Guid>
{
    public string Name { get; set; }

    public Example()
    {
        
    }
    public Example(Guid id, string name)
    {
        Id= id;
        Name= name;
    }
}
 ```

  ```Csharp
  public interface IExampleRepository:IRepository<Example,Guid>
{
}
 ```
 
  ```Csharp
 internal sealed class ExampleRepository : Repository<Example, Guid, BaseDbContext>, IExampleRepository
{
    public ExampleRepository(BaseDbContext context) : base(context)
    {
    }
}

 ```

  ```Csharp
  services.AddScoped<IBrandRepository, BrandRepository>();
 ```

  ```Csharp
   public class GetListExampleQuery : IRequest<GetListResponse<GetListExampleListItemDto>>
{
    public PageRequest PageRequest { get; set; }
}
 ```

   ```Csharp
    internal sealed class GetListExampleQueryHandler(
    IExampleRepository exampleRepository,
    IMapper mapper
    ) : IRequestHandler<GetListExampleQuery, GetListResponse<GetListExampleListItemDto>>
{
    public async Task<GetListResponse<GetListExampleListItemDto>> Handle(GetListExampleQuery request, CancellationToken cancellationToken)
    {
       IPaginate<Example> examples = await exampleRepository.GetListAsync(
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );

        GetListResponse<GetListExampleListItemDto> response = mapper.Map<GetListResponse<GetListExampleListItemDto>>(examples);
        return response;
    }
}
 ```

