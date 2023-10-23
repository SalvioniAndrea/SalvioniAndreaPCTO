using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ProgettoPtco.Data
{
    public class TemperatureDBContext : DbContext
    {
        public TemperatureDBContext() : base() { }
        public TemperatureDBContext(DbContextOptions<TemperatureDBContext> options) 
            : base(options) { }
        public DbSet<Detection> detections { get; set; }

    }
}
