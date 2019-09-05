using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string TextToDisplay;
        public string DataDirectory;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Anchor = AnchorStyles.None;
            button1.TextAlign = ContentAlignment.MiddleCenter;
            button2.Anchor = AnchorStyles.None;
            button2.TextAlign = ContentAlignment.MiddleCenter;
            domainUpDown1.Anchor = AnchorStyles.None;
            UpdateInitializationFile("read");
        }
        private void Form1_FormClosing (Object sender, FormClosingEventArgs e)
        {
            UpdateInitializationFile("write");
        }
        private void UpdateInitializationFile(string ReadOrWrite)
        {
            button1.Enabled = false;
            string InitializationFile = "Process.ini.txt";
            if (ReadOrWrite == "read")
            {
                string[] InitializationData = File.ReadAllLines(InitializationFile);
                string TestDirectory = InitializationData[0];
                if(Directory.Exists(TestDirectory))
                {
                    DataDirectory = TestDirectory;
                }
                else
                {
                    DataDirectory = ":C\\";
                }
            }
            else
            {
                if (Directory.Exists(DataDirectory))
                {
                    string[] IniFileContents = new string[1];
                    IniFileContents[0] = DataDirectory;
                    File.WriteAllLines(InitializationFile, IniFileContents);
                }
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog browsedialog = new OpenFileDialog();
            browsedialog.InitialDirectory = DataDirectory;
            TextToDisplay = browsedialog.FileName;
            browsedialog.Filter = "txt|*.txt";
            if (browsedialog.ShowDialog() == DialogResult.OK)
            {
                DataDirectory = Path.GetDirectoryName(browsedialog.FileName) + "\\";
                string[] TXTFiles = Directory.GetFiles(DataDirectory, "*.txt");
                for (int i = 0; i < TXTFiles.Length; i++)
                {
                    domainUpDown1.Items.Add(TXTFiles[i]);
                }
                button1.Enabled = true;
                domainUpDown1.Text = TXTFiles[0];
                for (int j = 0; j < TXTFiles.Length; j++)
                {
                    if (TXTFiles[j].Contains(TextToDisplay))
                    {
                        domainUpDown1.Text = TXTFiles[j];
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApp2.API_Processing data = new WindowsFormsApp2.API_Processing();
            string InputTextFileDirectory = DataDirectory;
            string InputTextFile = domainUpDown1.Text;
            string[] InputTextfFileCheck = File.ReadAllLines(InputTextFile);
            string[] FoldersToWrite = new string[InputTextfFileCheck.Length] ;
            string day = "0";
            string month = "0";
            string year = "0";          
            for (int i = 0; i < InputTextfFileCheck.Length; i++)
            {
                FoldersToWrite[i] = InputTextFileDirectory + "\\" + InputTextfFileCheck[i]+ "\\";
            }            
            for(int i = 0; i < InputTextfFileCheck.Length; i++)
            {
                if (InputTextfFileCheck[i].Contains("/"))
                {
                    string[] DayMonthYear = InputTextfFileCheck[i].Split('/');
                    month = DayMonthYear[0];
                    day = DayMonthYear[1];
                    year = DayMonthYear[2];
                    API_Calling_Form1();
                }
                else if (InputTextfFileCheck[i].Contains(","))
                {
                    string[] DayMonthYear = InputTextfFileCheck[i].Split(',');
                    string month_day_combined = DayMonthYear[0];
                    year = DayMonthYear[1].Substring(3);
                    string[] month_words = month_day_combined.Split(' ');
                    string month_string;
                    month_string = month_words[0];
                    day = month_words[1];
                    if (month_string == "January")
                    {
                        month_string = "1";
                    }
                    else if (month_string == "February")
                    {
                        month_string = "2";
                    }
                    else if (month_string == "March")
                    {
                        month_string = "3";
                    }
                    else if (month_string == "April")
                    {
                        month_string = "4";
                    }
                    else if (month_string == "May")
                    {
                        month_string = "5";
                    }
                    else if (month_string == "June")
                    {
                        month_string = "6";
                    }
                    else if (month_string == "July")
                    {
                        month_string = "7";
                    }
                    else if (month_string == "August")
                    {
                        month_string = "8";
                    }
                    else if (month_string == "September")
                    {
                        month_string = "9";
                    }
                    else if (month_string == "October")
                    {
                        month_string = "10";
                    }
                    else if (month_string == "November")
                    {
                        month_string = "11";
                    }
                    else if (month_string == "December")
                    {
                        month_string = "12";
                    }
                    month = month_string;
                    API_Calling_Form1();
                }
                else if (InputTextfFileCheck[i].Contains("-"))
                {
                    string[] DayMonthYear = InputTextfFileCheck[i].Split('-');
                    year = DayMonthYear[2].Substring(2);
                    day = DayMonthYear[1];
                    string month_string = DayMonthYear[0];
                    if (month_string == "Jan")
                    {
                        month_string = "1";
                    }
                    else if (month_string == "Feb")
                    {
                        month_string = "2";
                    }
                    else if (month_string == "Mar")
                    {
                        month_string = "3";
                    }
                    else if (month_string == "Apr")
                    {
                        month_string = "4";
                    }
                    else if (month_string == "May")
                    {
                        month_string = "5";
                    }
                    else if (month_string == "Jun")
                    {
                        month_string = "6";
                    }
                    else if (month_string == "Jul")
                    {
                        month_string = "7";
                    }
                    else if (month_string == "Aug")
                    {
                        month_string = "8";
                    }
                    else if (month_string == "Sep")
                    {
                        month_string = "9";
                    }
                    else if (month_string == "Oct")
                    {
                        month_string = "10";
                    }
                    else if (month_string == "Nov")
                    {
                        month_string = "11";
                    }
                    else if (month_string == "Dec")
                    {
                        month_string = "12";
                    }
                    month = month_string;
                    API_Calling_Form1();
                }
            }
            button1.Text = "Check folders!";
            void API_Calling_Form1()
            {
                try
                {
                    string API_Key = "&api_key=ubRD32WulEKYk8j5mtGFcfUyr1jvXA8fMkDaz605";
                    string API_Link = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=20" + year + "-" + month.Substring(0, 1) + "-" + day + API_Key;
                    string API_Calling_Output = data.API_Calling(API_Link);
                    string[] API_Calling_Split = API_Calling_Output.Split(':');
                    List<string> Photos_List = new List<string>();
                    foreach (var phrase in API_Calling_Split)
                    {
                        Photos_List.Add(phrase);
                    }
                    List<string> Links_List = new List<string>();
                    for (int i = 0; i < Photos_List.Count; i++)
                    {
                        if (Photos_List[i].Contains("mars.jpl.nasa"))
                        {
                            Links_List.Add(Photos_List[i]);
                        }
                    }
                    for (int j = 0; j < Links_List.Count; j++)
                    {
                        Links_List[j] = "http:" + Links_List[j];
                        Links_List[j] = Links_List[j].Substring(0, Links_List[j].Length - 10);
                    }
                    string[] Link_File_Names = new string[Links_List.Count];
                    string[] Link_File_Directory = new string[Links_List.Count];
                    for (int k = 0; k < Links_List.Count; k++)
                    {
                        if (Links_List[k].Contains("cam"))
                        {
                            int i = Links_List[k].IndexOf("cam");
                            Link_File_Names[k] = Links_List[k].Substring(i + 4, Links_List[k].Length - i - 8);
                            Link_File_Directory[k] = Links_List[k].Substring(0, i + 4);
                        }

                        else if (Links_List[k].Contains("mrdi"))
                        {
                            int i = Links_List[k].IndexOf("mrdi");
                            Link_File_Names[k] = Links_List[k].Substring(i + 5, Links_List[k].Length - i - 9);
                            Link_File_Directory[k] = Links_List[k].Substring(0, i + 5);
                        }
                        else if (Links_List[k].Contains("mhli"))
                        {
                            int i = Links_List[k].IndexOf("mhli");
                            Link_File_Names[k] = Links_List[k].Substring(i + 5, Links_List[k].Length - i - 9);
                            Link_File_Directory[k] = Links_List[k].Substring(0, i + 5);
                        }
                    }
                    string remoteUri;
                    string fileName;
                    string myStringWebResource = null;
                    WebClient myWebClient = new WebClient();
                    string FileDirectory;

                    if (month.Length == 1 && day.Length == 1)
                    {
                        FileDirectory = DataDirectory + "0" + month + "0" + day + year + "\\";
                    }
                    else if (month.Length == 1 && day.Length == 2)
                    {
                        FileDirectory = DataDirectory + "0" + month + day + year + "\\";
                    }
                    else if (month.Length == 2 && day.Length == 1)
                    {
                        FileDirectory = DataDirectory + month + "0" + day + year + "\\";
                    }
                    else
                    {
                        FileDirectory = DataDirectory + month + day + year + "\\";
                    }
                    for (int i = 0; i < Links_List.Count; i++)
                    {
                        remoteUri = Link_File_Directory[i];
                        fileName = Link_File_Names[i];
                        myStringWebResource = remoteUri + fileName;
                        if(!Directory.Exists(FileDirectory))
                        {
                            Directory.CreateDirectory(FileDirectory);
                        }
                        myWebClient.DownloadFile(myStringWebResource, @FileDirectory + fileName);
                    }
                }
                catch(Exception error)
                {
                    Console.WriteLine("An error has occurred: " + error.Message);
                }                           
            }
        }
    }
}