using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class Achievement: IComparable
{
    public string id;
    public string playerName;
    public string prizeMoney;
    public int numberOfQues;

    public Achievement()
    {

    }

    public Achievement(string id, string playerName, string prizeMoney, int numberOfQues)
    {
        this.id = id;
        this.playerName = playerName;
        this.prizeMoney = prizeMoney;
        this.numberOfQues = numberOfQues;
    }

    public int CompareTo(object obj)
    {
        if (obj == null)
            return 1;
        Achievement achievement = obj as Achievement;

        if (this.numberOfQues > achievement.numberOfQues)
            return 1;
        else if (this.numberOfQues < achievement.numberOfQues)
            return -1;
        else
            return 0;
    }
}
