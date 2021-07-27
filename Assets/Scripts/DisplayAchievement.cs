using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAchievement : MonoBehaviour
{
    public Text playerNameText;
    public Text scoreText;

    public void SetText(string name, int score)
    {
        playerNameText.text = name;
        scoreText.text = score.ToString();
    }
}
