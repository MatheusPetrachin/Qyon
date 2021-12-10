using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Api.Model
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }
    }
}
