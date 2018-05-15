using System.Threading;
using System.Windows;
using CipherGenerator.Configuration;

namespace CipherGenerator
{
    public partial class App
    {
        private Mutex _mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            _mutex = new Mutex(true, "Szyfrogram", out var instance);
            if (instance)
            {
                base.OnStartup(e);
                var bootsrapter = new Bootstrapper();
                bootsrapter.Run();
            }
            else
            {
                MessageBox.Show("Aplikacja działa", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                _mutex = null;
                Current.Shutdown();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _mutex?.ReleaseMutex();
            _mutex?.Close();
            base.OnExit(e);
        }

    }
}

