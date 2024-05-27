using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace workspace.Data
{
    public class SKDbContext : DbContext
    {
        public SKDbContext(DbContextOptions<SKDbContext> options)
            : base(options)
        {
        }
    }
}