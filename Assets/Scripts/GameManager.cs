using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    bool playerHasAnswered;
    bool isGameOver;
    int currentLevel;

    //delegate void UpdateCurrentLevel(int currentlevel);

    //event UpdateCurrentLevel currentlevelChanged;
    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }

    public int CurrentLevel
    {
        get => currentLevel;
        set 
        {
            currentLevel = value;
            StartCoroutine(GameGUIManager.Ins.ShowCurrentMoney());
        }
    }

    public bool PlayerHasAnswered { get => playerHasAnswered; set => playerHasAnswered = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public override void Start()
    {
        LoadQuest();
    }

    void Update()
    {
    }

    public void LoadQuest()
    {
        if(currentLevel < 15)
        {
            GameGUIManager.Ins.ResetQuesPanel();
            GameGUIManager.Ins.LoadQuestion(QuestManager.Ins.GetRandomQues());
            PlayerHasAnswered = false;
        }
    }
}
