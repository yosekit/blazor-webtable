namespace WebTable.Client.Services
{
    interface ITableService<T>
    {
        Task<List<T>> GetAllAsync();
    }
}
