using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CRM.EntityFramework
{
    public class CRM_DbContextFactory : IDesignTimeDbContextFactory<CRM_DbContext>
    {
        public CRM_DbContext CreateDbContext(string[]? args = null)
        {
            var options = new DbContextOptionsBuilder<CRM_DbContext>();
            options.UseMySQL("Data Source=mysql.nethely.hu;Database=sdsoftcrm;Port=3306;Password=bajarmilan2001;Username=sdsoftcrm");
            return new CRM_DbContext(options.Options);
        }
    }
}
