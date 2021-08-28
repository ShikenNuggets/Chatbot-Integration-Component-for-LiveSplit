using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using LiveSplit.UI;

namespace ChatBotIntegration{
	public partial class CBISettings : UserControl{
		public string TextFilePath { get; set; }
        public string SrcUsername { get; set; }

        public event EventHandler SettingChanged;

        public CBISettings(){
            InitializeComponent();

            TextFilePath = null;
            SrcUsername = null;

            OutputTextBox.DataBindings.Add("Text", this, "TextFilePath", true, DataSourceUpdateMode.OnPropertyChanged).BindingComplete += OnSettingChanged;
            SrcTextBox.DataBindings.Add("Text", this, "SrcUsername", true, DataSourceUpdateMode.OnPropertyChanged).BindingComplete += OnSettingChanged;
        }

        private void OnSettingChanged(object sender, BindingCompleteEventArgs e){
            SettingChanged?.Invoke(this, e);
        }

        public LayoutMode Mode { get; internal set; }

        internal XmlNode GetSettings(XmlDocument document){
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent){
            return SettingsHelper.CreateSetting(document, parent, "Version", "0.1") ^
                SettingsHelper.CreateSetting(document, parent, "TextFilePath", TextFilePath) ^
                SettingsHelper.CreateSetting(document, parent, "SrcUsername", SrcUsername);
        }

        internal void SetSettings(XmlNode settings){
            TextFilePath = SettingsHelper.ParseString(settings["TextFilePath"]);
            SrcUsername = SettingsHelper.ParseString(settings["SrcUsername"]);
        }
	}
}
