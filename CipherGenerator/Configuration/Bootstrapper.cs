using System.Threading;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace CipherGenerator.Configuration
{
    public class Bootstrapper : UnityBootstrapper
    {
       

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<View.MainWindow>();
        }

        protected override void InitializeShell()
        {
           



      
                    Application.Current.MainWindow?.Show();
         
        }

   
    }
}
