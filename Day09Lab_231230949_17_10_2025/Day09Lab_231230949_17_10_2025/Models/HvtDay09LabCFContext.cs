using Microsoft.EntityFrameworkCore;

namespace Day09Lab_231230949_17_10_2025.Models
{
    public class HvtDay09LabCFContext: DbContext
    {
        public HvtDay09LabCFContext(DbContextOptions<HvtDay09LabCFContext> options) : base(options) { }
        public DbSet<HvtLoai_San_Pham> hvtLoai_San_Phams { get; set; }
        public DbSet<HvtSan_Pham> hvtSan_Phams { get; set; }
    }
}
