using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace FileBackups
{
    [DataContract]
    public class ListBoxItemViewModel : ViewModelBase
    {
        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public string Description { get; set; }

        public string SaveDir => $"{Environment.CurrentDirectory}\\bak\\{Time}";

        public ListBoxItemViewModel Self => this;
    }
}
