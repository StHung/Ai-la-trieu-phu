using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuManager : MonoBehaviour
{
    public GameObject AchievementTable;
    public List<DisplayAchievement> displayAchievements;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowAchievements()
    {
        AchievementTable.SetActive(true);
        List<Achievement> achievements = DataProvider.Ins.GetAchievements();
        foreach (DisplayAchievement item in displayAchievements)
        {
            item.SetText(achievements[displayAchievements.IndexOf(item)].playerName,
                         achievements[displayAchievements.IndexOf(item)].numberOfQues);
        }
    }

    public void CloseTable()
    {
        AchievementTable.SetActive(false);
    }
}
