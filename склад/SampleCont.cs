using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace склад
{
    internal class SampleCont
    {
        public class SampleContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
        {
            public ApplicationContext CreateDbContext(string[] args)
            => new ApplicationContext(DataBaseHellper.Options());
        }
    }
}
