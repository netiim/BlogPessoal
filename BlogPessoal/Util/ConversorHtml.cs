using Aspose.Words;
using Aspose.Words.Saving;
using System.Text.RegularExpressions;

namespace BlogPessoal.Util
{
    public abstract class ConversorHtml
    {
        public static string ConverteDOCXemHTML(Document doc)
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
            TratarHtml(ref html);
            List<string> codigoImagens = EncontrarImagens(html);
            RenderizadorImagens.AdicionaImagens(codigoImagens, ref html);
            return html;
        }
        static List<string> EncontrarImagens(string texto)
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

        private static void TratarHtml(ref string html)
        {
            string primeiroTexto = "Evaluation Only. Created with Aspose.Words. Copyright 2003-2023 Aspose Pty Ltd.";
            string segundoTexto = "Created with an evaluation copy of Aspose.Words. To discover the full versions of our APIs please visit: https://products.aspose.com/words/";
            string styleTexto = "style=\"-aw-headerfooter-type:header-primary; clear:both\"";
            
            html = html.Replace(primeiroTexto, "").Replace(segundoTexto, "").Replace(styleTexto, "style=\"-aw-headerfooter-type:header-primary; clear:both; display: none;\"");
        }
    }
}
