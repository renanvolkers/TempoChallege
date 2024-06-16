namespace Tempo.Knight.Infra
{

    /// <summary>
    /// Interface reive config json para conected into data base
    /// </summary>
    public interface IDataBaseConfig
    {
        string DataBaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
