using SeriesApp.Samples;
using Xunit;

namespace SeriesApp.EntityFrameworkCore.Applications;

[Collection(SeriesAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SeriesAppEntityFrameworkCoreTestModule>
{

}
