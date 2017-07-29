using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using QnAMakerDialog;

namespace QnABot.Dialogs
{
    [Serializable]
    [QnAMakerService("cc4c35274f5b45f2a3546d18e7fa3bbf", "93dcf6d6-9273-4ccb-a431-512153ae85f6")]

    public class RootDialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync($"Sorry, I couldn't find an answer for '{originalQueryText}'.");
            context.Wait(MessageReceived);
        }

        [QnAMakerResponseHandler(50)]
        public async Task LowScoreHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            await context.PostAsync($"I found an answer that might help...{result.Answer}.");
            context.Wait(MessageReceived);
        }
    }
}