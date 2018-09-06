
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using System.IO;

namespace FileBackups
{
    
    public class ViewModelLocator
    {
      
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
        }

        static MainViewModel _main = null;
        public MainViewModel Main
        {
            get
            {
                if(_main == null)
                {
                    if(File.Exists("main.data"))
                    {
                        var content = File.ReadAllText("main.data");
                        _main = JsonConvert.DeserializeObject<MainViewModel>(content);
                    }
                    else
                    {
                        _main = new MainViewModel();
                    }
                }
                return _main;
            }
        }
        
        public static void Cleanup()
        {

        }
    }
}