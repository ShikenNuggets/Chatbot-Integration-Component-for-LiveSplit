using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace ChatBotIntegration{
	public class CBIComponent : LogicComponent{
		protected CBISettings Settings { get; set; }
		protected LiveSplitState State;

		public override string ComponentName => "Chatbot Integration";

		public override XmlNode GetSettings(XmlDocument document){
			return Settings.GetSettings(document);
		}

		public override Control GetSettingsControl(LayoutMode mode){
			Settings.Mode = mode;
			return Settings;
		}

		public override void SetSettings(XmlNode settings){
			Settings.SetSettings(settings);
		}

		public CBIComponent(LiveSplitState state){
			State = state;
			Settings = new CBISettings();

			state.OnSplit += OnUpdateNeeded;
			state.OnReset += OnReset;
			state.OnSkipSplit += OnUpdateNeeded;
			state.OnUndoSplit += OnUpdateNeeded;
			state.OnStart += OnUpdateNeeded;
			//state.RunManuallyModified += OnUpdateNeeded;

			UpdateData();
		}

		private void OnUpdateNeeded(object sender, EventArgs e){
			UpdateData();
		}

		protected void OnReset(object sender, TimerPhase value){
			UpdateData();
		}

		private void UpdateData(){
			if(string.IsNullOrWhiteSpace(Settings.TextFilePath) || !System.IO.Directory.Exists(Settings.TextFilePath)){
				return;
			}

			var pb = State.Run.Last().PersonalBestSplitTime.RealTime;
			if(State.CurrentTimingMethod == TimingMethod.GameTime){
				pb = State.Run.Last().PersonalBestSplitTime.GameTime;
			}

			var sob = SumOfBest.CalculateSumOfBest(State.Run, State.Settings.SimpleSumOfBest, true, State.CurrentTimingMethod);
			var wr = GetWorldRecord();

			string pbText = "N/A";
			string sobText = "N/A";
			string wrText = "Unknown World Record";
			string runStatusText = "Unknown";

			if(pb.HasValue){
				pbText = GetTimeString(pb.Value);
			}

			if(State.Run.Count >= 1 && sob.HasValue){
				sobText = GetTimeString(sob.Value);
			}

			//TODO - Cache WR so that it doesn't fail when SR.C API divebombs
			if(wr != null && wr.Times != null && wr.Times.Primary.HasValue){
				string user;
				if(wr.Player != null && !string.IsNullOrWhiteSpace(wr.Player.Name)){
					user = wr.Player.Name;
				}else if(wr.Player != null && !string.IsNullOrWhiteSpace(wr.Player.GuestName)){
					user = wr.Player.GuestName;
				}else{
					user = "Unknown User";
				}

				if(!string.IsNullOrWhiteSpace(Settings.SrcUsername) && user == Settings.SrcUsername){
					user = "me";
				}

				wrText = GetTimeString(wr.Times.Primary.Value) + " by " + user;
			}

			if(State.CurrentSplitIndex > 0 && State.Run[State.CurrentSplitIndex - 1].SplitTime.RealTime.HasValue && State.Run[State.CurrentSplitIndex - 1].PersonalBestSplitTime.RealTime.HasValue){
				var runBehindPB = TimeSpan.Compare(State.Run[State.CurrentSplitIndex - 1].SplitTime.RealTime.Value, State.Run[State.CurrentSplitIndex - 1].PersonalBestSplitTime.RealTime.Value) == 1;
				if(runBehindPB){
					runStatusText = "Run is bad :(";
				}else{
					runStatusText = "Run is good :)";
				}
			}

			string pbFile = Settings.TextFilePath + "\\PB.txt";
			if(!System.IO.File.Exists(pbFile) || System.IO.File.ReadAllText(pbFile) != pbText){
				System.IO.File.WriteAllText(pbFile, pbText);
			}

			string sobFile = Settings.TextFilePath + "\\SoB.txt";
			if(!System.IO.File.Exists(sobFile) || System.IO.File.ReadAllText(sobFile) != sobText){
				System.IO.File.WriteAllText(sobFile, sobText);
			}

			string wrFile = Settings.TextFilePath + "\\WR.txt";
			if(!System.IO.File.Exists(wrFile) || System.IO.File.ReadAllText(wrFile) != wrText){
				System.IO.File.WriteAllText(wrFile, wrText);
			}

			string rsFile = Settings.TextFilePath + "\\RunStatus.txt";
			if(!System.IO.File.Exists(rsFile) || System.IO.File.ReadAllText(rsFile) != runStatusText){
				System.IO.File.WriteAllText(rsFile, runStatusText);
			}
		}

		public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode){}

		public override void Dispose(){}

		private SpeedrunComSharp.Record GetWorldRecord(){
			foreach(IComponent c in State.Layout.Components){
				if(c != null && c is LiveSplit.WorldRecord.UI.Components.WorldRecordComponent wrc && wrc.WorldRecord != null){
					return wrc.WorldRecord;
				}
			}

			return null;
		}

		//I'm like 95% sure that C# already solved this problem and that I didn't need to write this function...
		//But this is fine for now
		private string GetTimeString(TimeSpan t){
			int secs = (int)Math.Floor(t.TotalSeconds);
			int minutes = 0;
			int hours = 0;

			while(secs >= 60){
				secs -= 60;
				minutes++;
			}

			while(minutes >= 60){
				minutes -= 60;
				hours++;
			}

			string result = "";

			if(hours > 0){
				result += hours.ToString() + ":";
			}

			if(minutes >= 10 || (hours <= 0 && minutes > 0 && minutes < 10)){
				result += minutes.ToString() + ":";
			}else if(hours > 0 && minutes >= 0 && minutes < 10){
				result += "0" + minutes.ToString() + ":";
			}

			if(secs >= 10 || (minutes == 0 && hours == 0)){
				result += secs.ToString();
			}else if(secs < 10){
				result += "0" + secs.ToString();
			}

			return result;
		}
	}
}