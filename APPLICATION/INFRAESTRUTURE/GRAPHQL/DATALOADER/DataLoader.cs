using APPLICATION.DOMAIN.CONTRACTS.RESPOSITORIES.CEP;
using APPLICATION.DOMAIN.DTOS.RESPONSE;
using APPLICATION.DOMAIN.UTILS.EXTENSIONS;

namespace APPLICATION.INFRAESTRUTURE.GRAPHQL.DATALOADER;

public class GetCepByIdsDataLoader : GroupedDataLoader<Guid, CepResponse>
{
    private readonly ICepRepository _cepRepository;

    public GetCepByIdsDataLoader(ICepRepository cepRepository, IBatchScheduler batchScheduler, DataLoaderOptions options) : base(batchScheduler, options)
    {
        _cepRepository = cepRepository ?? throw new ArgumentNullException(nameof(cepRepository));
    }

    protected override async Task<ILookup<Guid, CepResponse>> LoadGroupedBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
    {
        var ceps = await _cepRepository.GetWithExpression(x => keys.Contains(x.Id)).Result.ToCepResponse(); return ceps.ToLookup(x => x.id);
    }
}

public class GetCepByCepsDataLoader : GroupedDataLoader<string, CepResponse>
{
    private readonly ICepRepository _cepRepository;

    public GetCepByCepsDataLoader(ICepRepository cepRepository, IBatchScheduler batchScheduler, DataLoaderOptions options) : base(batchScheduler, options)
    {
        _cepRepository = cepRepository ?? throw new ArgumentNullException(nameof(cepRepository));
    }

    protected override async Task<ILookup<string, CepResponse>> LoadGroupedBatchAsync(IReadOnlyList<string> keys, CancellationToken cancellationToken)
    {
        var ceps = await _cepRepository.GetWithExpression(x => keys.Contains(x.Cep)).Result.ToCepResponse(); return ceps.ToLookup(x => x.cep);
    }
}