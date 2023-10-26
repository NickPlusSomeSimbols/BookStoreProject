

using BookStoreProjectCore.Model;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface IInnlineLocationService
    {
        public Task<string> PostLocationAsync(InnlineLocationDto innlineLocationDto);
        Task<List<InnlineLocationDto>> GetLocationAsync(int v1, string date1, string date2, int v2, bool v3, int v4);
    }
}
