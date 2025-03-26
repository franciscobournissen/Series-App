using SeriesApp.Books;
using Xunit;

namespace SeriesApp.EntityFrameworkCore.Applications.Books;

[Collection(SeriesAppTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<SeriesAppEntityFrameworkCoreTestModule>
{

}