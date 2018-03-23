using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace laico.bot.Dialogs
{
    public class EleicoesDialog
    {
        public static async Task Actions(IDialogContext context)
        {
            var message = context.MakeMessage();

            var heroCard = new HeroCard();
            heroCard.Title = "LAICO";
            heroCard.Subtitle = "Eleições";
            heroCard.Images = new List<CardImage>()
            {
                //Biometria
                new CardImage("http://www.ipcan.com.br/wp-content/uploads/2016/05/biometria-foto.jpg", "Biometria")
                //Urna
                ,new CardImage("http://www.alencastroveiga.com.br/file/clip/o-urna-facebook-178.jpg", "Urna Eletrônica")
                //História
                ,new CardImage("https://cdn.govexec.com/media/img/upload/2016/04/29/Carahsoft_Symantec_shutterstock/govexec-full-width.jpg", "História")
                //
            };

            message.Attachments.Add(heroCard.ToAttachment());

            await context.PostAsync(message);
        }
    }
}