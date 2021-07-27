using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.Linq;
public class DataProvider
{
    private static DataProvider ins;

    string fileName;
    string filePath;
    XmlDocument doc;
    XmlElement root;
    public DataProvider()
    {
        fileName = "savedata.xml";
        filePath = Application.persistentDataPath + "/" + fileName;
        doc = new XmlDocument();
        if (!File.Exists(filePath))
        {
            XmlElement rootNode = doc.CreateElement("list");

            for (int i = 0; i < 3; i++)
            {
                XmlElement achievement = doc.CreateElement("achievement");
                achievement.SetAttribute("id", i.ToString());

                XmlElement playerName = doc.CreateElement("playername");
                playerName.InnerText = "Trống";

                XmlElement prizeMoney = doc.CreateElement("prizemoney");
                prizeMoney.InnerText = "0";

                XmlElement numberOfQues = doc.CreateElement("numberofques");
                numberOfQues.InnerText = "0";

                achievement.AppendChild(playerName);
                achievement.AppendChild(prizeMoney);
                achievement.AppendChild(numberOfQues);

                rootNode.AppendChild(achievement);

                doc.AppendChild(rootNode);
                doc.Save(filePath);
            }
        }

        doc.Load(filePath);
        root = doc.DocumentElement;
    }

    public static DataProvider Ins
    {
        get
        {
            if (ins == null)
                ins = new DataProvider();
            return ins;
        }
    }


    public List<Achievement> GetAchievements()
    {
        List<Achievement> list = new List<Achievement>();

        XmlNodeList nodes = root.SelectNodes("achievement");

        foreach (XmlNode item in nodes)
        {
            Achievement achievement = new Achievement();
            achievement.id = item.Attributes[0].Value;
            achievement.playerName = item.SelectSingleNode("playername").InnerText;
            achievement.prizeMoney = item.SelectSingleNode("prizemoney").InnerText;
            achievement.numberOfQues = int.Parse(item.SelectSingleNode("numberofques").InnerText);
            list.Add(achievement);
        }
        list.Sort();
        list.Reverse();
        return list;
    }

    public Achievement GetLowestAchievement()
    {
        return GetAchievements().Min();
    }

    public void SaveNewAchievement(string playername, string prizemoney, int numOfQues)
    {
        Achievement achievement = GetLowestAchievement();
        XmlNode node = root.SelectSingleNode($"achievement[@id=\'{achievement.id}\']");
        if (node != null)
        {
            node.SelectSingleNode("playername").InnerText = playername;
            node.SelectSingleNode("prizemoney").InnerText = prizemoney;
            node.SelectSingleNode("numberofques").InnerText = numOfQues.ToString();
            doc.Save(filePath);
        }
    }
}
