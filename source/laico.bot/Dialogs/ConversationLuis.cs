using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace laico.bot.Dialogs
{
    [Serializable]
    //[LuisModel("b51c211f-7b5c-4e22-bc73-d86aee5eb60e", "cf39568e030e4e12b104539fa51df9c9")]
    [LuisModel("5f8e53e5-2a84-4056-9ab1-cb043589e5b9", "cf39568e030e4e12b104539fa51df9c9")]
    public class ConversationLuisDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Desculpe, não consegui entender a sua frase **" + result.Query + "**");
        }

        [LuisIntent("localizacao")]
        public async Task Localizacao(IDialogContext context, LuisResult result)
        {
            var feiras = result.Entities?.Select(e => e.Entity);

            await context.PostAsync($"Você entrou na parte de localização {string.Join(",", feiras.ToArray())} ");
        }

        [LuisIntent("saudacao")]
        public async Task Saudacao(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá eu sou um Bot, estou sempre aprendendo.");
        }

        [LuisIntent("sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá eu sou um Bot, estou sempre aprendendo.");
        }

        [LuisIntent("cumprimentos")]
        public async Task Cumprimentos(IDialogContext context, LuisResult result)

        {
            await context.PostAsync("Olá, como vai você ?");
        }        
    }
}