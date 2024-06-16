namespace Tempo.Knight.Infra
{
    /// <summary>
    /// Class reive config json para conected into data base
    /// </summary>
    public class DataBaseConfig : IDataBaseConfig
    {
        public string DataBaseName { get; set; }
        public string ConnectionString { get; set; }
        public DataBaseConfig(string dataBaseName, string connectionString)
        {
            DataBaseName = dataBaseName;
            ConnectionString = connectionString;
        }
    }
}
