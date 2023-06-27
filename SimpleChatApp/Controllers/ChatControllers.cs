using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.Chat;

namespace SimpleChatApp.Controllers
{
	public class ChatController : Controller
	{
		private static readonly IList<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();
		// could change it up to Dictionary<string, List<string>> later
		// it could use repositories 

		public IActionResult Show()
		{
			if (messages.Count() < 1)
			{
				return View(new ChatViewModel());
			}

			var chatModel = new ChatViewModel()
			{
				Messages = messages.Select(m => new MessageViewModel()
				{
					Sender = m.Key,
					MessageText = m.Value
				}).ToList()
			};
			return View(chatModel);
		}
		[HttpPost]
		public IActionResult Send(ChatViewModel chat)
		{
			var newMessage = chat.CurrentMessage;
			messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

			return RedirectToAction("Show");
		}
	}
}
