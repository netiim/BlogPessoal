using Google.Apis.Drive.v3;
using Google.Apis.Sheets.v4;

namespace BlogPessoal.Interfaces;

public interface IAutenticavel
{
    DriveService GetDriveService();
    SheetsService GetSheetsService();
}