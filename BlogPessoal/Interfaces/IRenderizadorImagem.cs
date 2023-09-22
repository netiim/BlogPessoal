using Aspose.Words;

namespace BlogPessoal.Interfaces
{
    public interface IRenderizadorImagem
    {
        void AdicionaImagens(List<string> codigoImagens, ref string html);

    }
}
