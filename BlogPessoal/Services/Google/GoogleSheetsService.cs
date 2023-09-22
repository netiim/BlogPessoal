using BlogPessoal.Interfaces;
using BlogPessoal.Util;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace BlogPessoal.Services.Google
{
    public class GoogleSheetsService : ISheetService
    {
        private SheetsService _sheetService;

        public GoogleSheetsService(IAutenticavel authenticator)
        {
            _sheetService = authenticator.GetSheetsService();
        }
        public Dictionary<string, string> PreencherMapeamentoImagens()
        {
            string idDoArquivo = "14WAhfvLWZSaJbsB-OS3WcQu_ZdYi1121dwVIvuUZ2Ns";

            var range = "A:B";

            SpreadsheetsResource.ValuesResource.GetRequest request = _sheetService.Spreadsheets.Values.Get(idDoArquivo, range);

            ValueRange response = request.Execute();

            IList<IList<object>> values = response.Values;

            var result = LeitorPlanilha.LerPlanilha(values);

            return result;
        }
    }
}