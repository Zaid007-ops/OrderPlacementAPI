using ChatGPT.Net.DTO.ChatGPT;
using ChatGPT.Net;
using Newtonsoft.Json;

namespace OrderPlacement.ChatGPT
{
    public class ChatGptRepository
    {
        public string AskQuestion(string question)
        {
            var bot = new ChatGpt("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");
            bot.ClearConversations();
            bot.SetConversation("1234", new ChatGptConversation());
            var answer = bot.Ask(question, "1234").Result;
            return answer;

        }
    }
}
