﻿using BlogPessoal.Services;
using Google.Apis.Sheets.v4;

namespace BlogPessoal.Util;

public class RenderizadorImagens
{
    public Dictionary<string, string> mapImagens;
    public void AdicionaImagens(List<string> codigoImagens, ref string html)
    {
        foreach (var item in codigoImagens)
        {
            KeyValuePair<string, string> imagem = EncontraUrlImagemByMapImagens($"{item}", mapImagens);

            string img = $"<div style=\"text-align: center;\"> <img src=\"{imagem.Value}\" alt=\"Minha Imagem\" style=\"margin: 0 auto;\"> </div> ";
           
            html = html.Replace(imagem.Key, img);
        }
    }

    public KeyValuePair<string,string> EncontraUrlImagemByMapImagens(string item, Dictionary<string, string> mapImagens)
    {
        // como o item é pego pelo regex e o regex pega tudo que ta entre @# ele perde esse caracteres, mas na hora de dar replace no html vamos precisar deles então somente para compararmos aqui vamos remover da key
        KeyValuePair<string, string> imagem = mapImagens.FirstOrDefault(imagem => imagem.Key.Replace("@","").Replace("#","") == item);

        return !string.IsNullOrWhiteSpace(imagem.Key)
            && !string.IsNullOrWhiteSpace(imagem.Value) ? imagem : new KeyValuePair<string, string>(item, item);
    }
}
