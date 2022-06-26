namespace WebTable.Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TableColumn> Columns { get; set; }
        public DbSet<TableColumnType> ColumnTypes { get; set; }
        public DbSet<TableRow> Rows { get; set; }
        public DbSet<TableItem> Items { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableColumn>()
                .Property(c => c.TypeId)
                .HasConversion<int>();

            modelBuilder.Entity<TableColumnType>()
                .Property(t => t.Id)
                .HasConversion<int>();

            // ceed column types
            modelBuilder.Entity<TableColumnType>().HasData(
                Enum.GetValues(typeof(TableColumnTypeId))
                .Cast<TableColumnTypeId>()
                .Select(type => new TableColumnType()
                {
                    Id = type,
                    Name = type.ToString()
                })
            );

            // ceed default first column
            modelBuilder.Entity<TableColumn>()
                .HasData(new TableColumn { Id = 1 });
        }
    }
}
