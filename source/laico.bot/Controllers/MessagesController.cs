﻿using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using laico.bot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;

namespace laico.bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        //public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        //{
        //    //var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

        //    //var attributes = new LuisModelAttribute(
        //    //    ConfigurationManager.AppSettings["LuisId"],
        //    //    ConfigurationManager.AppSettings["LuisSubscriptionKey"]);

        //    //var service = new LuisService(attributes);

        //    //switch (activity.Type)
        //    //{
        //    //    case ActivityTypes.Message:
        //    //        await Conversation.SendAsync(activity, () => new LuisConversationDialog());
        //    //        break;
        //    //    case ActivityTypes.ConversationUpdate:
        //    //        if(activity.MembersAdded.Any(o => o.Id == activity.Recipient.Id))
        //    //        {
        //    //            var reply = activity.CreateReply();
        //    //            reply.Text = "Olá, sou a LAICO o seu assistente virtual político. \nFaça uma pergunta que terei o prazer em tentar responder.";
        //    //            //await Conversation.SendAsync(activity, () => activity.pos)
        //    //        }
        //    //        break;
        //    //}

        //    //if (activity.Type == ActivityTypes.Message)
        //    //{
        //    //    //await Conversation.SendAsync(activity, () => new Dialogs.RootDialog());
        //    //    await Conversation.SendAsync(activity, () => new LuisConversationDialog());
        //    //}
        //    //else
        //    //{
        //    //    HandleSystemMessage(activity);
        //    //}
        //    //var response = Request.CreateResponse(HttpStatusCode.OK);
        //    //return response;

        //    if (activity.Type == ActivityTypes.Message)
        //    {
        //        await Conversation.SendAsync(activity, () => new LuisConversationDialog());
        //    }
        //    else
        //    {
        //        HandleSystemMessage(activity);
        //    }
        //    var response = Request.CreateResponse(HttpStatusCode.OK);
        //    return response;
        //}

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, () => new ConversationLuisDialog());
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {                
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            System.Diagnostics.Debug.WriteLine(message.Type.ToString());
            return null;
        }
    }
}