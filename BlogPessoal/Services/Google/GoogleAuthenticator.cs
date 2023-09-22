using BlogPessoal.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace BlogPessoal.Services.Google;

public class GoogleAuthenticator : IAutenticavel
{
    private static string ApplicationName = "BlogPessoal";
    private static string ServiceAccountKeyPath = "C:\\Users\\Pessoal\\Desktop\\BlogPessoal\\BlogPessoal\\bin\\Debug\\net6.0\\credentials.json";
    private GoogleCredential _credential;

    public GoogleAuthenticator()
    {
        using (var stream = new FileStream(ServiceAccountKeyPath, FileMode.Open, FileAccess.Read))
        {
            _credential = GoogleCredential.FromStream(stream);
        }
    }

    public DriveService GetDriveService()
    {
        var service = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = _credential.CreateScoped(DriveService.Scope.Drive),
            ApplicationName = ApplicationName,
        });

        return service;
    }

    public SheetsService GetSheetsService()
    {
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = _credential.CreateScoped(SheetsService.Scope.Spreadsheets),
            ApplicationName = ApplicationName,
        });

        return service;
    }
}
