using Microsoft.Win32;

namespace NetworkModelCode.Desktop.Services
{
    public interface IDialogService
    {
        string FileName { get; set; }
        bool OpenFile();
        bool SaveFile();
    }

    public class DefaultDialogService : IDialogService
    {
        public string FileName { get; set; }

        public bool OpenFile()
        {
            FileName = string.Empty;

            var openFileDialog = new OpenFileDialog();
            Configure(openFileDialog);

            if((bool)openFileDialog.ShowDialog())
            {
                FileName = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        public bool SaveFile()
        {
            FileName = string.Empty;

            var saveFileDialog = new SaveFileDialog();
            Configure(saveFileDialog);

            if((bool)saveFileDialog.ShowDialog())
            {
                FileName = saveFileDialog.FileName;
                return true;
            }

            return false;
        }

        private void Configure(FileDialog fileDialog)
        {
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
        }
    }
}
