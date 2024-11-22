using MyWebApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MyWebApi.Services
{
    public class EmployeesService
    {
        private readonly IMongoCollection<Employee> _employeesCollection;

        public EmployeesService(IOptions<EmployeeManagementDatabaseSettings> employeeManagementDatabaseSettings)
        {
            var mongoClient = new MongoClient(employeeManagementDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(employeeManagementDatabaseSettings.Value.DatabaseName);
            _employeesCollection = mongoDatabase.GetCollection<Employee>(employeeManagementDatabaseSettings.Value.EmployeesCollectionName);
        }

        public async Task<List<Employee>> GetAsync() =>
            await _employeesCollection.Find(_ => true).ToListAsync();
        public async Task<Employee?> GetAsync(string id) =>
            await _employeesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Employee newEmployee) =>
            await _employeesCollection.InsertOneAsync(newEmployee);

        public async Task UpdateAsync(string id, Employee updatedEmployee) =>
            await _employeesCollection.ReplaceOneAsync(x => x.Id == id, updatedEmployee);

        public async Task RemoveAsync(string id) =>
            await _employeesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
