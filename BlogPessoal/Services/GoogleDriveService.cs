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
        private static string ApplicationName = "BlogPessoal";
        private static string ServiceAccountKeyPath = "C:\\Users\\Pessoal\\Desktop\\BlogPessoal\\BlogPessoal\\bin\\Debug\\net6.0\\credentials.json"; 

        public static DriveService AutenticarContaDeServico()
        {
            GoogleCredential credential;

            using (var stream = new FileStream(ServiceAccountKeyPath, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(DriveService.Scope.Drive);
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return service;
        }

        public static string ObterConteudoDocxComoHtml(DriveService servicoDrive, string idDoArquivo)
        {
            var request = servicoDrive.Files.Export(idDoArquivo, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            using (var stream = new MemoryStream())
            {
                request.Download(stream);

                string html = Util.ConversorHtml.ConverteDOCXemHTML(new Document(stream));

                return html;
            }
        }
    }
}


