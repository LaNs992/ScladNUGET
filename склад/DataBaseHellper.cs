using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace склад
{
    public static class DataBaseHellper
    { 
            public static DbContextOptions<ApplicationContext> Options()
            {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            return optionBuilder
            .UseSqlServer(connectionString: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"
)
                .Options;
        }
    }
        
    }
