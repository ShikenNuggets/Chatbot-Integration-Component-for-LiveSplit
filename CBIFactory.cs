using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace ChatBotIntegration{
	class CBIFactory : IComponentFactory{
		public string ComponentName => "Chatbot Integration";
		public string Description => "Prints data into various text files to be used by bots";
		public ComponentCategory Category => ComponentCategory.Other;
		public IComponent Create(LiveSplitState state) => new CBIComponent(state);
		public string UpdateName => ComponentName;
		public string XMLURL => "http://livesplit.org/update/Components/update.BotIntegration.xml";
		public string UpdateURL => "http://livesplit.org/update/";
		public Version Version => Version.Parse("0.1.1");
	}
}