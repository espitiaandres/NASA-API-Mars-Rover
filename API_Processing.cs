using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Drawing;

namespace WindowsFormsApp2
{
    class API_Processing
    {
        public string API_Calling(string strurltest)
        {
            WebRequest requestObjGet = WebRequest.Create(strurltest);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string strresulttest = null;
            using (Stream stream = responseObjGet.GetResponseStream()) //Imports data from the API as a "stream"
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }
            return strresulttest;
        }
        public string getBetween (string strSource, string strStart, string strEnd, List<string> Photos_List)
        {
            int Start = 0;
            int End = 0;
            string String_To_Be_Added = "";
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                String_To_Be_Added = "https" + strSource.Substring(Start, End - Start) + ".JPG";
                return String_To_Be_Added;
            }            
            else
            {
                return "";
            }
        }
        public Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;
                WebResponse webResponse = webRequest.GetResponse();
                Stream stream = webResponse.GetResponseStream();
                image = Image.FromStream(stream);
                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return image;
        }
        internal Image DownloadImageFromUrl(object p)
        {
            throw new NotImplementedException();
        }
    }
}
