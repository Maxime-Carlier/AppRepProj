namespace VelibApplication
{
    partial class VelibApplication
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuitButton = new System.Windows.Forms.Button();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.DepartureTextBox = new System.Windows.Forms.TextBox();
            this.ArrivalTextBox = new System.Windows.Forms.TextBox();
            this.DepartureLabel = new System.Windows.Forms.Label();
            this.ArrivalLabel = new System.Windows.Forms.Label();
            this.GMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.SuggestionListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(12, 96);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(116, 23);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(156, 96);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(116, 23);
            this.ValidateButton.TabIndex = 1;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // DepartureTextBox
            // 
            this.DepartureTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.DepartureTextBox.Location = new System.Drawing.Point(89, 30);
            this.DepartureTextBox.Name = "DepartureTextBox";
            this.DepartureTextBox.Size = new System.Drawing.Size(171, 20);
            this.DepartureTextBox.TabIndex = 2;
            this.DepartureTextBox.TextChanged += new System.EventHandler(this.DepartureTextBox_TextChanged);
            // 
            // ArrivalTextBox
            // 
            this.ArrivalTextBox.Location = new System.Drawing.Point(89, 56);
            this.ArrivalTextBox.Name = "ArrivalTextBox";
            this.ArrivalTextBox.Size = new System.Drawing.Size(171, 20);
            this.ArrivalTextBox.TabIndex = 3;
            this.ArrivalTextBox.TextChanged += new System.EventHandler(this.ArrivalTextBox_TextChanged);
            // 
            // DepartureLabel
            // 
            this.DepartureLabel.AutoSize = true;
            this.DepartureLabel.Location = new System.Drawing.Point(23, 33);
            this.DepartureLabel.Name = "DepartureLabel";
            this.DepartureLabel.Size = new System.Drawing.Size(54, 13);
            this.DepartureLabel.TabIndex = 4;
            this.DepartureLabel.Text = "Departure";
            this.DepartureLabel.Click += new System.EventHandler(this.DepartureLabel_Click);
            // 
            // ArrivalLabel
            // 
            this.ArrivalLabel.AutoSize = true;
            this.ArrivalLabel.Location = new System.Drawing.Point(32, 59);
            this.ArrivalLabel.Name = "ArrivalLabel";
            this.ArrivalLabel.Size = new System.Drawing.Size(36, 13);
            this.ArrivalLabel.TabIndex = 5;
            this.ArrivalLabel.Text = "Arrival";
            this.ArrivalLabel.Click += new System.EventHandler(this.ArrivalLabel_Click);
            // 
            // GMapControl
            // 
            this.GMapControl.Bearing = 0F;
            this.GMapControl.CanDragMap = true;
            this.GMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMapControl.GrayScaleMode = false;
            this.GMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapControl.LevelsKeepInMemmory = 5;
            this.GMapControl.Location = new System.Drawing.Point(297, 12);
            this.GMapControl.MarkersEnabled = true;
            this.GMapControl.MaxZoom = 18;
            this.GMapControl.MinZoom = 0;
            this.GMapControl.MouseWheelZoomEnabled = true;
            this.GMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMapControl.Name = "GMapControl";
            this.GMapControl.NegativeMode = false;
            this.GMapControl.PolygonsEnabled = true;
            this.GMapControl.RetryLoadTile = 0;
            this.GMapControl.RoutesEnabled = true;
            this.GMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMapControl.ShowTileGridLines = false;
            this.GMapControl.Size = new System.Drawing.Size(633, 462);
            this.GMapControl.TabIndex = 6;
            this.GMapControl.Zoom = 12D;
            // 
            // SuggestionListBox
            // 
            this.SuggestionListBox.FormattingEnabled = true;
            this.SuggestionListBox.Location = new System.Drawing.Point(15, 166);
            this.SuggestionListBox.Name = "SuggestionListBox";
            this.SuggestionListBox.Size = new System.Drawing.Size(244, 147);
            this.SuggestionListBox.TabIndex = 7;
            this.SuggestionListBox.Visible = false;
            this.SuggestionListBox.SelectedValueChanged += new System.EventHandler(this.SuggestionListBox_SelectedValueChanged);
            // 
            // VelibApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 486);
            this.Controls.Add(this.SuggestionListBox);
            this.Controls.Add(this.GMapControl);
            this.Controls.Add(this.ArrivalLabel);
            this.Controls.Add(this.DepartureLabel);
            this.Controls.Add(this.ArrivalTextBox);
            this.Controls.Add(this.DepartureTextBox);
            this.Controls.Add(this.ValidateButton);
            this.Controls.Add(this.QuitButton);
            this.Name = "VelibApplication";
            this.Text = "VelibApplication";
            this.Load += new System.EventHandler(this.VelibApplication_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.TextBox DepartureTextBox;
        private System.Windows.Forms.TextBox ArrivalTextBox;
        private System.Windows.Forms.Label DepartureLabel;
        private System.Windows.Forms.Label ArrivalLabel;
        private GMap.NET.WindowsForms.GMapControl GMapControl;
        private System.Windows.Forms.ListBox SuggestionListBox;
    }
}

