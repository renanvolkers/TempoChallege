namespace Tempo.Knight.Infra
{
    public interface IDataBaseConfig
    {
        string DataBaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
