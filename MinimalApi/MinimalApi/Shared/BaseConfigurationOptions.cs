namespace MinimalApi.Shared
{
    public class BaseConfigurationOptions
    {
        public const string BaseConfig = "BaseConfiguration";
        public string? NomeAplicacao { get; set; }
        public string? Descricao { get; set; }

        public BaseConfigurationOptions() { }

    }
}
