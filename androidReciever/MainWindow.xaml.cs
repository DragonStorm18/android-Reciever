using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace androidReciever
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // HttpListener listener;
        public MainWindow()
        {
            InitializeComponent();


        }
       
        Thread t;
        string Ip, Port;
       // string prefixes;
        HttpListener listener = new HttpListener();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void InvokeIP()
        {
            Ip = txtIP.Text;
        }

        public void InvokePort()
        {
            Port = txtPort.Text;
        }

        public delegate void InvokeDelegate();
        private void RunListener()
        {
            txtIP.Dispatcher.BeginInvoke(new InvokeDelegate(InvokeIP));
            txtPort.Dispatcher.BeginInvoke(new InvokeDelegate(InvokePort));



            //try
            // {
            // Create a listener.

            // Add the prefixes.
            

            
            //prefixes = "http://" + Ip.ToString() + ":" + Port.ToString() + "/";
            //listener.Prefixes.Add(prefixes);
            // }
            // catch (HttpListenerException)
            // {
            //System.Windows.Forms.MessageBox.Show("Not a Valid IP address");
            //t.Abort();
            // listener.Stop();
            // }
            // catch (NullReferenceException)
            //{
            //    System.Windows.Forms.MessageBox.Show("Not a Valid IP address");
            //    // t.Abort();
            //    listener = new HttpListener();
            //}
           // listener.Start();
        
            while (true)
            {
                if (!HttpListener.IsSupported)
                {
                    Console.WriteLine(@"Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                    return;
                }
                // URI prefixes are required,
                try
                {
                    string prefixes = "http://" + Ip.ToString() + ":" + Port.ToString() + "/";
                // Note: The GetContext method blocks while waiting for a request. 
                
                    listener.Prefixes.Add(prefixes);
                
                listener.Start();
                }
                catch (NullReferenceException)
                {
                }
                catch (HttpListenerException)
                {
                    //IGNORE 
                }
                var context = listener.GetContext();
                var body = new StreamReader(context.Request.InputStream).ReadToEnd();
                var requestBody = JsonConvert.DeserializeObject<Message>(body);

                // Obtain a response object.
                var response = context.Response;

                // App Logic here

                if (requestBody == null)
                {
                    Console.WriteLine("NULL");
                }
                else
                if (requestBody.Volume == "fire")
                {
                    Console.WriteLine("FIRE!!");
                    // System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe");
                    System.Diagnostics.Process.Start("https://www.youtube.com");    
                

                    // System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                    
                }
                else
                if (requestBody.Volume == "ENTER")
                {
                    Console.WriteLine("Enter!!");
                    SendKeys.SendWait("{ENTER}");
                }
                else
                if (requestBody.Volume == "media")
                {
                    Console.WriteLine("MEDIA!!");
                    System.Diagnostics.Process.Start("E:\\Program Files (x86)\\Kodi\\Kodi.exe");
                }
                else
                if (requestBody.Volume == "UP")
                {
                    Console.WriteLine("UP!!");
                    SendKeys.SendWait("{UP}");
                }
                else
                if (requestBody.Volume == "DOWN")
                {
                    Console.WriteLine("Down!!");
                    SendKeys.SendWait("{DOWN}");
                }
                else
                if (requestBody.Volume == "LEFT")
                {
                    Console.WriteLine("Left!!");
                    SendKeys.SendWait("{LEFT}");
                }
                else
                if (requestBody.Volume == "RIGHT")
                {
                    Console.WriteLine("RIGHT!!");
                    SendKeys.SendWait("{RIGHT}");
                }
                else
                if (requestBody.Volume == "INFO")
                {
                    Console.WriteLine("INFO!!");
                    SendKeys.SendWait("i");
                }
                else
                if (requestBody.Volume == "BACK")
                {
                    Console.WriteLine("BACK!!");
                    SendKeys.SendWait("{BACKSPACE}");
                }
                else
                if (requestBody.Volume == "VOLUP")
                {
                    Console.WriteLine("VOLUME UP!!");
                    SendKeys.SendWait("=");
                }
                else
                if (requestBody.Volume == "VOLDOWN")
                {
                    Console.WriteLine("VOlume DOWN!!");
                    SendKeys.SendWait("-");
                }
                else
                if (requestBody.Volume == "SEND")
                {
                    Console.WriteLine("TEXT YALL!!");
                    SendKeys.SendWait(requestBody.Mute.ToString());
                }
                else
                if (requestBody.Volume == "TAB")
                {
                    Console.WriteLine("TAB");
                    SendKeys.SendWait("{TAB}");
                }
                Thread.Sleep(4000);
            }

            //if (requestBody.Volume == "movie")
            //{
            //    Console.WriteLine("MOVIE!!");
            //   

            //}

            //var buffer = System.Text.Encoding.UTF8.GetBytes(requestBody.Volume + " " + requestBody.Mute);
            //// Get a response stream and write the response to it.
            //response.ContentLength64 = buffer.Length;
            //var output = response.OutputStream;
           //output.Write(buffer, 0, buffer.Length);
            //// You must close the output stream.
            //output.Close();
          // listener.Stop();
           
        }
    


       
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
           
            // Create a listener.
            //listener = new HttpListener();
            //// Add the prefixes.
            // listener.Prefixes.Add("http://" + Ip.ToString() + ":" + Port.ToString() + "/");
            //string prefixes = "http://" + Ip.ToString() + ":" + Port.ToString() + "/";
           // listener.Prefixes.Add(prefixes);
            //RunListener();
            t = new Thread(new ThreadStart(RunListener)) {IsBackground=true};
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            listener.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

      

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
           // try
           // {
               listener.Stop();
                t.Abort();
                btnStop.IsEnabled = false;
                btnStart.IsEnabled = true;
           // }
           // catch(NullReferenceException)
            //{
           //     System.Windows.MessageBox.Show("Please close the app and start again");
           // }
        }

        
    }
}
