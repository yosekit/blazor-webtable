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
                .Property(c => c.Type)
                .HasConversion<string>();

            modelBuilder.Entity<TableColumnType>()
                .Property(t => t.Name)
                .HasConversion<string>();

            // default first column
            modelBuilder.Entity<TableColumn>()
                .HasData(new TableColumn
                {
                    Id = 1,
                    Name = "Name",
                    TypeId = 1,
                    Type = TableColumnType.DataType.Text,
                });
        }
    }
}
