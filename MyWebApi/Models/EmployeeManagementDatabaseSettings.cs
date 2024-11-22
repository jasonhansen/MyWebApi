namespace MyWebApi.Models
{
    public class EmployeeManagementDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string EmployeesCollectionName { get; set; } = null!;
    }
}
