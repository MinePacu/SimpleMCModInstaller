namespace SimpleMCModInstaller
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Add_ModFile_Button = new Button();
            Install_Button = new Button();
            ModList_dataGridView = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            removeModButton = new Button();
            progressBar1 = new ProgressBar();
            InstallingFileText = new Label();
            ((System.ComponentModel.ISupportInitialize)ModList_dataGridView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // Add_ModFile_Button
            // 
            Add_ModFile_Button.Location = new Point(3, 3);
            Add_ModFile_Button.Name = "Add_ModFile_Button";
            Add_ModFile_Button.Size = new Size(75, 23);
            Add_ModFile_Button.TabIndex = 0;
            Add_ModFile_Button.Text = "모드 추가";
            Add_ModFile_Button.UseVisualStyleBackColor = true;
            Add_ModFile_Button.Click += Add_ModFile_Button_Click;
            // 
            // Install_Button
            // 
            Install_Button.Location = new Point(165, 3);
            Install_Button.Name = "Install_Button";
            Install_Button.Size = new Size(75, 23);
            Install_Button.TabIndex = 1;
            Install_Button.Text = "설치";
            Install_Button.UseVisualStyleBackColor = true;
            Install_Button.Click += Install_Button_Click;
            // 
            // ModList_dataGridView
            // 
            ModList_dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ModList_dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ModList_dataGridView.Location = new Point(3, 32);
            ModList_dataGridView.Name = "ModList_dataGridView";
            ModList_dataGridView.RowTemplate.Height = 25;
            ModList_dataGridView.Size = new Size(762, 374);
            ModList_dataGridView.TabIndex = 2;
            ModList_dataGridView.SelectionChanged += ModList_dataGridView_SelectionChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(Add_ModFile_Button);
            flowLayoutPanel1.Controls.Add(removeModButton);
            flowLayoutPanel1.Controls.Add(Install_Button);
            flowLayoutPanel1.Controls.Add(ModList_dataGridView);
            flowLayoutPanel1.Controls.Add(progressBar1);
            flowLayoutPanel1.Controls.Add(InstallingFileText);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(776, 467);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // removeModButton
            // 
            removeModButton.Location = new Point(84, 3);
            removeModButton.Name = "removeModButton";
            removeModButton.Size = new Size(75, 23);
            removeModButton.TabIndex = 5;
            removeModButton.Text = "모드 제거";
            removeModButton.UseVisualStyleBackColor = true;
            removeModButton.Click += removeModButton_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.None;
            progressBar1.Location = new Point(3, 412);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(762, 23);
            progressBar1.TabIndex = 3;
            // 
            // InstallingFileText
            // 
            InstallingFileText.AutoSize = true;
            InstallingFileText.Location = new Point(771, 409);
            InstallingFileText.Name = "InstallingFileText";
            InstallingFileText.Size = new Size(0, 15);
            InstallingFileText.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 491);
            Controls.Add(flowLayoutPanel1);
            Name = "MainForm";
            SizeChanged += MainForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)ModList_dataGridView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Add_ModFile_Button;
        private Button Install_Button;
        private DataGridView ModList_dataGridView;
        private FlowLayoutPanel flowLayoutPanel1;
        private ProgressBar progressBar1;
        private Label InstallingFileText;
        private Button removeModButton;
    }
}
