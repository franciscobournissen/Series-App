using Xunit;

namespace SeriesApp.EntityFrameworkCore;

[CollectionDefinition(SeriesAppTestConsts.CollectionDefinitionName)]
public class SeriesAppEntityFrameworkCoreCollection : ICollectionFixture<SeriesAppEntityFrameworkCoreFixture>
{

}
