using SeriesApp.Samples;
using Xunit;

namespace SeriesApp.EntityFrameworkCore.Domains;

[Collection(SeriesAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SeriesAppEntityFrameworkCoreTestModule>
{

}
