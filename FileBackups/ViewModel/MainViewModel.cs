using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Input;

namespace FileBackups
{

    [DataContract]
    public class MainViewModel : ViewModelBase
    {
        [DataMember]
        public ObservableCollection<ListBoxItemViewModel> ItemSource { get; set; } = new ObservableCollection<ListBoxItemViewModel>();

        [DataMember]
        public string SourcePath { get; set; }

        [DataMember]
        public string SaveDescription { get; set; }


        #region Command

        public ICommand UnDoCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand OpenSourcePathCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        #endregion

        public MainViewModel()
        {
            UnDoCommand = new RelayCommand<object>(UnDoCommandExcute);
            DeleteCommand = new RelayCommand<object>(DeleteCommandExcute);
            OpenSourcePathCommand = new RelayCommand(OpenSourcePathCommandExcute);
            SaveCommand = new RelayCommand(SaveCommandExcute);
        }

        #region Command Excute Mothod

        private void UnDoCommandExcute(object value)
        {
            var item = value as ListBoxItemViewModel;

            if (item == null)
                return;

            CopyFiles(item.SaveDir, this.SourcePath);

        }

        private void DeleteCommandExcute(object value)
        {
            var item = value as ListBoxItemViewModel;

            if (item == null)
                return;

            //if(MessageBox.Show($"是否确认删除\r\n{item.Time}\r\n{item.Description}", "提示", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
            //{
            //    return;
            //}

            DeleteFiles(item.SaveDir);

            ItemSource.Remove(item);
        }

        private void OpenSourcePathCommandExcute()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择要保存的目录";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    System.Windows.MessageBox.Show("文件夹路径不能为空", "提示");
                    return;
                }

                SourcePath = dialog.SelectedPath;
            }
        }

        private void SaveCommandExcute()
        {
            ListBoxItemViewModel item = new ListBoxItemViewModel()
            {
                Time = DateTime.Now.ToString("yyyyMMddHHmmss"),
                Description = this.SaveDescription,
                Path = this.SourcePath,
            };

            CopyFiles(item.Path, item.SaveDir);

            this.ItemSource.Insert(0, item);
        }

        #endregion

        #region Helper Mothod

        private void CopyFiles(string from, string to)
        {
            var files = GetAllFiles(from);

            for (int i = 0; i < files.Length; i++)
            {
                var newDir = $"{to}{Path.GetDirectoryName(files[i]).Replace(from, "")}";
                var newPath = $"{newDir}\\{Path.GetFileName(files[i])}";

                if(!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                }

                try { File.Delete(newPath); } catch { }

                File.Copy(files[i], newPath);
;           }
        }


        private void DeleteFiles(string path)
        {
            if (!Directory.Exists(path)) return;

            var dirs = Directory.GetDirectories(path);
            for (int i = 0; i < dirs.Length; i++)
            {
                DeleteFiles(dirs[i]);
            }

            var files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                try { File.Delete(files[i]); } catch { }
            }

            try { Directory.Delete(path); } catch { }
        }

        private string[] GetAllFiles(string name)
        {
            if(!Directory.Exists(name))
            {
                return new string[] { };
            }

            var fileList = new List<string>();

            var dirs = Directory.GetDirectories(name);
            for (int i = 0; i < dirs.Length; i++)
            {
                fileList.AddRange(GetAllFiles(dirs[i]));
            }
            var files = Directory.GetFiles(name);
            fileList.AddRange(files);

            return fileList.ToArray();
        }

        #endregion
    }
}