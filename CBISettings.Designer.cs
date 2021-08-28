
namespace ChatBotIntegration
{
	partial class CBISettings
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
        {
			this.OutputLabel = new System.Windows.Forms.Label();
			this.CreditsLabel = new System.Windows.Forms.Label();
			this.SrcLabel = new System.Windows.Forms.Label();
			this.SrcTextBox = new System.Windows.Forms.TextBox();
			this.OutputTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// OutputLabel
			// 
			this.OutputLabel.AutoSize = true;
			this.OutputLabel.Location = new System.Drawing.Point(4, 50);
			this.OutputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.OutputLabel.Name = "OutputLabel";
			this.OutputLabel.Size = new System.Drawing.Size(84, 17);
			this.OutputLabel.TabIndex = 1;
			this.OutputLabel.Text = "Output Path";
			// 
			// CreditsLabel
			// 
			this.CreditsLabel.AutoSize = true;
			this.CreditsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CreditsLabel.Location = new System.Drawing.Point(4, 16);
			this.CreditsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.CreditsLabel.Name = "CreditsLabel";
			this.CreditsLabel.Size = new System.Drawing.Size(251, 17);
			this.CreditsLabel.TabIndex = 4;
			this.CreditsLabel.Text = "Chatbot Integration by ShikenNuggets\r\n";
			// 
			// SrcLabel
			// 
			this.SrcLabel.AutoSize = true;
			this.SrcLabel.Location = new System.Drawing.Point(4, 94);
			this.SrcLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SrcLabel.Name = "SrcLabel";
			this.SrcLabel.Size = new System.Drawing.Size(165, 17);
			this.SrcLabel.TabIndex = 5;
			this.SrcLabel.Text = "speedrun.com username";
			// 
			// SrcTextBox
			// 
			this.SrcTextBox.Location = new System.Drawing.Point(177, 94);
			this.SrcTextBox.Name = "SrcTextBox";
			this.SrcTextBox.Size = new System.Drawing.Size(205, 22);
			this.SrcTextBox.TabIndex = 6;
			// 
			// OutputTextBox
			// 
			this.OutputTextBox.Location = new System.Drawing.Point(95, 50);
			this.OutputTextBox.Name = "OutputTextBox";
			this.OutputTextBox.Size = new System.Drawing.Size(287, 22);
			this.OutputTextBox.TabIndex = 7;
			// 
			// BotSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.OutputTextBox);
			this.Controls.Add(this.SrcTextBox);
			this.Controls.Add(this.SrcLabel);
			this.Controls.Add(this.CreditsLabel);
			this.Controls.Add(this.OutputLabel);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "BotSettings";
			this.Size = new System.Drawing.Size(385, 149);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label CreditsLabel;
		private System.Windows.Forms.Label SrcLabel;
		private System.Windows.Forms.TextBox SrcTextBox;
		private System.Windows.Forms.TextBox OutputTextBox;
	}
}
