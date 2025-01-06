using System.ComponentModel;
using System.Diagnostics;

namespace SimpleMCModInstaller
{
    public partial class MainForm : Form
    {
        BackgroundWorker worker;
        List<string> modFileList = new();
        List<string> modFileList_WithPath = new();
        int nowfileIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            InstallingFileText.Text = "시작 대기 중..";
            removeModButton.Enabled = false;

            if (ModList_dataGridView.CurrentRow != null)
                removeModButton.Enabled = true;

            BindingList<filePathName> modFileList_Array = new BindingList<filePathName>() { };
            ModList_dataGridView.DataSource = modFileList_Array;

            ModList_dataGridView.Columns[0].HeaderText = "파일 이름";
            ModList_dataGridView.Columns[1].HeaderText = "파일 경로";
        }

        private void Add_ModFile_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = "jar 파일 (*.jar)|*.jar|모든 파일 (*.*)|*.*";

            dialog.FilterIndex = 0;
            dialog.Multiselect = true;

            BindingList<filePathName>? data = ModList_dataGridView.DataSource as BindingList<filePathName>;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine("dialog.FileNames.Length : " + dialog.FileNames.Length);
                if (dialog.FileNames.Length > 1)
                {
                    for (int i = 0; i < dialog.FileNames.Length; i++)
                    {
                        data?.Add(new filePathName { fileName = dialog.SafeFileNames[i], filePath = dialog.FileNames[i] });
                        modFileList.Add(dialog.SafeFileNames[i]);
                        modFileList_WithPath.Add(dialog.FileNames[i]);
                    }
                }

                else
                {
                    Debug.WriteLine("SelectedFileName : " + dialog.SafeFileName);
                    Debug.WriteLine("SelectedFilePath : " + dialog.FileName);

                    data?.Add(new filePathName { fileName = dialog.SafeFileName, filePath = dialog.FileName });
                    modFileList.Add(dialog.SafeFileName);
                    modFileList_WithPath.Add(dialog.FileName);
                }

                dialog.Dispose();
            }
        }

        private void Install_Button_Click(object sender, EventArgs e)
        {
            Add_ModFile_Button.Enabled = false;
            Install_Button.Enabled = false;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            InstallingFileText.Text = "작업 완료";
            MessageBox.Show("모드 설치가 완료되었습니다.");
            worker.Dispose();

            Add_ModFile_Button.Enabled = true;
            Install_Button.Enabled = true;
            InstallingFileText.Text = "시작 대기 중..";
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            InstallingFileText.Text = modFileList[nowfileIndex] + " 파일 작업 중..";
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            string minecraftmodsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\.minecraft\\mods\\";
            string minecraftPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\.minecraft\\";

            Debug.WriteLine("minecraft_mods_path : " + minecraftmodsPath);
            Debug.WriteLine("IsExistModsPath : " + Directory.Exists(minecraftmodsPath));

            BindingList<filePathName>? data = ModList_dataGridView.DataSource as BindingList<filePathName>;

            if (Directory.Exists(minecraftmodsPath))
            {
                for (int i = 0; data?.Count > i; i++)
                {
                    Thread.Sleep(50);
                    File.Copy(data[i].filePath, minecraftmodsPath + "\\" + data[i].fileName);
                    worker.ReportProgress((i + 1 / data.Count) * 100);
                    nowfileIndex = i;
                }
            }

            else if (Directory.Exists(minecraftPath))
            {
                MessageBox.Show("포지 Mod Loader가 설치되어 있지 않습니다. 재설치 후, 다시 시도하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                worker.CancelAsync();
            }

            else
            {
                MessageBox.Show("마인크래프트가 설치되어 있지 않지 않습니다. 재설치 후, 다시 시도하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                worker.CancelAsync();
            }
        }

        private void removeModButton_Click(object sender, EventArgs e)
        {
            BindingList<filePathName>? data = ModList_dataGridView.DataSource as BindingList<filePathName>;
            data?.RemoveAt(ModList_dataGridView.CurrentRow.Index);
        }

        private void ModList_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.SelectedRows.Count > 0)
                removeModButton.Enabled = true;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            int gridX = flowLayoutPanel1.Location.X;   //그리드컨트롤의 시작 X 좌표
            int gridY = flowLayoutPanel1.Location.Y;  //그리드컨트롤의 시작 Y 좌표

            flowLayoutPanel1.Width = this.Width - (gridX * 2 + 20); //보기 좋게 적당한 사이즈로 계산
            flowLayoutPanel1.Height = this.Height - gridY - 55; // 보기 좋게 적당한 사이즈로 계산

            progressBar1.Width = this.Width - (gridX * 2 + 20);

            ModList_dataGridView.Width = flowLayoutPanel1.Width - 30;
            ModList_dataGridView.Height = flowLayoutPanel1.Height - (progressBar1.Height + InstallingFileText.Height) - 50;
        }
    }
}
