using BlogPessoal.Services;
using BlogPessoal.Util;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogPessoal.Pages.Shared
{
    public class CadastrarTextoModel : PageModel
    {
        public string TitlePagina { get; set; }
        public string ConteudoHtml { get; set; }
        public void OnGet(string parametro)
        {
            TitlePagina = MapeadorDocumentos.GetTitleDocumento(parametro);
            DriveService servicoDrive = GoogleDriveService.AutenticarContaDeServico();
            string idDoArquivo = parametro;// GoogleDriveService.ObterIdDoArquivoPorNome(servicoDrive, parametro, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            
            if (idDoArquivo != null)
            {
                ConteudoHtml = GoogleDriveService.ObterConteudoDocxComoHtml(servicoDrive, idDoArquivo);                
            }
            else
            {
                ConteudoHtml = "Sem arquivo";
            }
        }
    }
}
