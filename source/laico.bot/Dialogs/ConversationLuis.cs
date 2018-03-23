using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
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

        [LuisIntent("saudacao")]
        public async Task Saudacao(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Olá eu sou o LAICO, seu assistente virtual.");
            await CardMessageSaudacao(context);
        }

        private static async Task CardMessageSaudacao(IDialogContext context)
        {
            var message = context.MakeMessage();

            var heroCard = new HeroCard();
            heroCard.Title = "LAICO";
            heroCard.Subtitle = "Assistente político virtual";
            heroCard.Images = new List<CardImage>
            {
                new CardImage("https://res.cloudinary.com/teepublic/image/private/s--uzVes9cE--/t_Preview/b_rgb:191919,c_limit,f_jpg,h_630,q_90,w_630/v1511519722/production/designs/2096240_1.jpg", "Eu sou o Laico")
            };

            message.Attachments.Add(heroCard.ToAttachment());

            await context.PostAsync(message);
        }

        [LuisIntent("quemsou")]
        public async Task QuemSou(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu sou o LAICO, seu assistente virtual político.");
            await CardMessageSaudacao(context);
            await context.PostAsync("Em que posso lhe ajudar?");
        }

        [LuisIntent("eleicoes")]
        public async Task Cumprimentos(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("O que deseja saber sobre as eleições?");

            await EleicoesDialog.Actions(context);
        }

        [LuisIntent("papel")]
        public async Task Papel(IDialogContext context, LuisResult result)
        {
            var entities = result.Entities?.Select(e => e.Entity);

            await context.PostAsync($"Você entrou em papel {string.Join(",", entities.ToArray())} ");
        }



    }
}