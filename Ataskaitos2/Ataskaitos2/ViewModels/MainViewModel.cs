using Ataskaitos2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Ataskaitos2.ViewModels
{
  
    public class MainViewContext : INotifyPropertyChanged
    {
        private ReportData data;
        public string DocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static DateTime Now { get; }

        public ReportData reportData
        {
            get
            {
                return data;
            }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewContext()
        {
            data = new ReportData();
            //reportData = new ReportData();
            SendData = new Command(SendEmail, DataIsValid);
            Login = new Command(LaunchLoginPage);
        }


        public void GenerateFile()
        {



        }
        public Command SendData
        {
            get;
           
        }
        public Command Login
        {
            get;

        }
       
        public void LaunchLoginPage()
        {
            Debug.WriteLine("Loggin in "+ DocumentPath+" namae "+Now );
            Debug.WriteLine(data.DataString);
           // WriteLocalFile(Now + ".csv", data.DataString);



        }

        public bool DataIsValid()
        {
            return true;
        }

        public void SendEmail()
        {
            Debug.WriteLine("Sending email");
            GenerateFile();

            
        }

        public void WriteLocalFile(string FileName, byte[] Data)
        {
            string filePath = Path.Combine(DocumentPath, FileName);
            File.WriteAllBytes(filePath, Data);
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
