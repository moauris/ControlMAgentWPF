using System;
using CtmaApp.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CtmaApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IO;

namespace CtmaApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            DataContext context = new DataContext();
            SeedData.PopulateData(context);

            var LoginWin = new LoginWindow();
            LoginWin.Show();

#if DEBUG
            //Enable Debug Trace Listener
            Trace.Listeners.Clear();
            string fileName = $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_CtmaApp.log";
            Stream myFileStream = File.Create(fileName);
            TraceListener listener = new TextWriterTraceListener(myFileStream);
            Trace.Listeners.Add(listener);
            Trace.Listeners.Add(new DefaultTraceListener());
#endif
        }
    }
}
