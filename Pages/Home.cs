using AutoGen.Core;
using AutoGen.LMStudio;

namespace ChatBot.Pages
{
    public partial class Home
    {
        private string? inputValue { get; set; }
        private List<string> messages { get; set; } = new List<string>();

        public async Task Chat(string? content)
        {
            if (content == null) { return; }
            var config = new LMStudioConfig("localhost", 1234);
            var lmAgent = new LMStudioAgent("Bobby", config: config)
                .RegisterPrintMessage();
            IMessage response = await lmAgent.SendAsync(content);
            messages.Add("User:   " + inputValue ?? string.Empty);
            messages.Add("Bobby:  " + response.GetContent());
            inputValue = null;
        }
    }
}