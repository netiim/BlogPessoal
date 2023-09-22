using Aspose.Words;
using Aspose.Words.Saving;
using BlogPessoal.Services;
using System.Text.RegularExpressions;

namespace BlogPessoal.Util
{
    public class ConversorHtml
    {
        private readonly RenderizadorImagens _renderizadorImagem;
        private readonly GoogleSheetsService _sheetService;
        public ConversorHtml(RenderizadorImagens renderizadorImagem, GoogleSheetsService sheetService)
        {
            _renderizadorImagem = renderizadorImagem;
            _sheetService = sheetService;
        }
        public string ConverteDOCXemHTML(Document doc)
        {
            HtmlSaveOptions saveOptions = new HtmlSaveOptions();
            saveOptions.CssStyleSheetType = CssStyleSheetType.Inline;
            saveOptions.ExportPageMargins = true;
            saveOptions.ImageResolution = 90;
            //Como uso a versão free o html tem uma logomarca atras
            saveOptions.ImagesFolder = "C:\\Users\\Pessoal\\Documents\\imagens";

            MemoryStream stream = new MemoryStream();
            doc.Save(stream, saveOptions);
            stream.Position = 0;

            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();
            OcultarCodigosPropagandas(ref html); //Usamos uma versão free essa parte da replace em alguns lugares
            List<string> codigoImagens = EncontrarCodigosImagensNoHTML(html);
            _renderizadorImagem.mapImagens = _sheetService.PreencherMapeamentoImagens();
            _renderizadorImagem.AdicionaImagens(codigoImagens, ref html);

            return html;
        }
        static List<string> EncontrarCodigosImagensNoHTML(string texto)
        {
            List<string> imagensEncontradas = new List<string>();

            // Expressão regular para encontrar conteúdo entre marcadores
            string pattern = $"{Regex.Escape("@#")}(.*?){Regex.Escape("#@")}";
            Regex regex = new Regex(pattern);
             
            MatchCollection matches = regex.Matches(texto);

            foreach (Match match in matches)
            {
                imagensEncontradas.Add(match.Groups[1].Value);
            }

            return imagensEncontradas;
        }

        private static void OcultarCodigosPropagandas(ref string html)
        {
            string primeiroTexto = "Evaluation Only. Created with Aspose.Words. Copyright 2003-2023 Aspose Pty Ltd.";
            string segundoTexto = "Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/";
            string styleTexto = "style=\"-aw-headerfooter-type:header-primary; clear:both\"";

            html = html.Replace(primeiroTexto, "").Replace(segundoTexto, "").Replace(styleTexto, "style=\"-aw-headerfooter-type:header-primary; clear:both; display: none;\"");
        }
    }
}
