namespace Minimalapi.Dominio.ModelViews
{
    public struct ErrosDeValidacao
    {
        public ErrosDeValidacao(object value)
        {
            // Inicializa a propriedade Mensagens
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}
