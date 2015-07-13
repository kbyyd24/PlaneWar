using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace PlaneWar
{
    struct result
    {
        public string status;
        public string reason;
        public List<Players> players;
    }
    struct Players
    {
        public string userName;
        public string score;
        public string rank;
    }
    class serverConnecter
    {
        private string uName;
        private result res;
        private readonly string url = "http://localhost/planewar/ranklist.php";

        public result Res
        {
            get
            {
                return res;
            }
        }

        public serverConnecter(string name)
        {
            uName = name;
            res.players = new List<Players>();
        }

        public void ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            string xml = GetPostString(uName);
            doc.LoadXml(xml);

            XmlElement root = doc.DocumentElement;
            res.status = root.SelectSingleNode("/xml/status").InnerText;
            res.reason = root.SelectSingleNode("/xml/reason").InnerText;
            XmlNodeList rootList = root.SelectNodes("/xml/players");
            foreach (XmlNode rootNode in rootList)
            {
                XmlNodeList childList = rootNode.ChildNodes;
                Players player;
                player.userName = childList[0].InnerText;
                player.score = childList[1].InnerText;
                player.rank = childList[2].InnerText;
                res.players.Add(player);
            }
        }

        private string GetPostString(string data)
        {
            try
            {
                byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(data);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "text/plain";
                myRequest.ContentLength = postBytes.Length;
                myRequest.Proxy = null;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postBytes, 0, postBytes.Length);
                newStream.Close();
                // Get response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
