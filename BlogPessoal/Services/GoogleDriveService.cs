using Aspose.Words;
using BlogPessoal.Util;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BlogPessoal.Services
{
    public class GoogleDriveService
    {
        private DriveService _driveService;
        private ConversorHtml _conversorHtml;

        public GoogleDriveService(GoogleAuthenticator authenticator, ConversorHtml conversorHtml)
        {
            _driveService = authenticator.GetDriveService();
            _conversorHtml = conversorHtml;
        }
        public string ObterConteudoDocxComoHtml(string idDoArquivo)
        { 
            var request = _driveService.Files.Export(idDoArquivo, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            using (var stream = new MemoryStream())
            {
                request.Download(stream);

                string html = _conversorHtml.ConverteDOCXemHTML(new Document(stream));

                return html;
            }
        }
    }
}


