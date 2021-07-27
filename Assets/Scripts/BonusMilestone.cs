using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BonusMilestone
{
    public static string GetCurrentMoneyLevel(int level)
    {
        string currentMoney = "";
        switch (level)
        {
            case 0:
                currentMoney = "0";
                break;
            case 1:
                currentMoney = "200.000";
                break;
            case 2:
                currentMoney = "400.000";
                break;
            case 3:
                currentMoney = "600.000";
                break;
            case 4:
                currentMoney = "1.000.000";
                break;
            case 5:
                currentMoney = "2.000.000";
                break;
            case 6:
                currentMoney = "3.000.000";
                break;
            case 7:
                currentMoney = "6.000.000";
                break;
            case 8:
                currentMoney = "10.000.000";
                break;
            case 9:
                currentMoney = "14.000.000";
                break;
            case 10:
                currentMoney = "22.000.000";
                break;
            case 11:
                currentMoney = "30.000.000";
                break;
            case 12:
                currentMoney = "40.000.000";
                break;
            case 13:
                currentMoney = "80.000.000";
                break;
            case 14:
                currentMoney = "85.000.000";
                break;
            case 15:
                currentMoney = "150.000.000";
                break;
        }

        return currentMoney;
    }
}
