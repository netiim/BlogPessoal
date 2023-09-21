using BlogPessoal.Services;
using BlogPessoal.Util;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPessoal.Pages.Shared
{
    public class CadastrarTextoModel : PageModel
    {
        private readonly GoogleDriveService _driveService;
        public CadastrarTextoModel(GoogleDriveService driveService)
        {
            _driveService = driveService;
        }
        public string TitlePagina { get; set; }
        public string ConteudoHtml { get; set; }
        public void OnGet(string parametro)
        {
            TitlePagina = MapeadorDocumentos.GetTitleDocumento(parametro);
            string idDoArquivo = parametro;
            
            if (idDoArquivo != null)
            {
                ConteudoHtml = _driveService.ObterConteudoDocxComoHtml(idDoArquivo);                
            }
            else
            {
                ConteudoHtml = "Sem arquivo";
            }
        }
    }
}
