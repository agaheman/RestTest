using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestTest.Infra.Data.Sql.Command;

public class RestTestContextFactory : IDesignTimeDbContextFactory<RestTestContext1>
{
    public RestTestContext1 CreateDbContext(string[] args)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<RestTestContext1>();
        dbContextOptionsBuilder.UseSqlServer("Server = 10.100.7.28; Database=CorporateBankingCommon ;User Id =Tl_ManabeDev_Team;Password=123@789#$QWE; MultipleActiveResultSets=true;TrustServerCertificate=True;Persist Security Info=True;Encrypt=false");

        return new RestTestContext1(dbContextOptionsBuilder.Options);
    }
}