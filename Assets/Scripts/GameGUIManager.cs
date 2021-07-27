using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject CurrentBountyDialog;

    public GameObject SettingsUI;

    public GameObject timeCounting;

    public Text questionText;

    public Button[] answerButtons;

    public Sprite[] buttonStates;

    public GameEndDialog gameEndDialog;

    public SaveDialog saveDialog;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    // Control game timeline
    public void LoadQuestion(Questions ques)
    {
        List<string> wrongAnswers = new List<string>() { ques.Answer1, ques.Answer2, ques.Answer3 };

        questionText.text = ques.QuestionContent;

        int randCorrectAnsBtn = Random.Range(0, answerButtons.Length);
        answerButtons[randCorrectAnsBtn].tag = "RightAnswer";

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            if (answerButtons[i].tag.Equals("Untagged"))
            {
                int randWrongAns = Random.Range(0, wrongAnswers.Count);
                string wrongAnsString = wrongAnswers[randWrongAns];
                wrongAnswers.RemoveAt(randWrongAns);
                answerButtons[i].GetComponentInChildren<Text>().text = wrongAnsString;
            }
            else if (answerButtons[i].tag.Equals("RightAnswer"))
            {
                answerButtons[i].GetComponentInChildren<Text>().text = ques.CorrectAnswwer;
            }
        }

        StartCountDown();
    }


    public void CheckAnswerEvent(Button ansBtn)
    {
        if (!GameManager.Ins.PlayerHasAnswered)
        {
            GameManager.Ins.PlayerHasAnswered = true;

            StopCountDown();

            StartCoroutine(ShowAnswer(ansBtn));
        }
    }




    IEnumerator ShowAnswer(Button ansBtn)
    {
        ansBtn.GetComponent<Image>().sprite = buttonStates[1];

        float waitTimes = 2f;
        while (waitTimes >= 0)
        {
            waitTimes--;
            yield return new WaitForSeconds(1);
        }

        if (ansBtn.tag.Equals("RightAnswer"))
        {
            AudioController.Ins.PlaySound(AudioController.Ins.rightAnsSound);
            ansBtn.GetComponent<Image>().sprite = buttonStates[3];
            GameManager.Ins.CurrentLevel++;
            float timeToLoadNextQues = 3f;
            while (timeToLoadNextQues >= 0)
            {
                timeToLoadNextQues--;
                yield return new WaitForSeconds(1f);
            }
            if (GameManager.Ins.CurrentLevel == 15)
            {
                saveDialog.ShowDialog(true);
            }
            else
            {
                GameManager.Ins.LoadQuest();
            }
        }
        else
        {
            AudioController.Ins.PlaySound(AudioController.Ins.badAnsSound);
            ansBtn.GetComponent<Image>().sprite = buttonStates[2];

            foreach (Button item in answerButtons)
            {
                if (item.tag.Equals("RightAnswer"))
                {
                    item.GetComponent<Image>().sprite = buttonStates[3];
                }
            }

            GameManager.Ins.IsGameOver = true;
            yield return new WaitForSeconds(3f);
            if (GameManager.Ins.CurrentLevel > DataProvider.Ins.GetLowestAchievement().numberOfQues)
            {
                saveDialog.ShowDialog(true);
            }
            else
            {
                gameEndDialog.SetText("Thành Tích",
                                       GameManager.Ins.CurrentLevel,
                                       BonusMilestone.GetCurrentMoneyLevel(GameManager.Ins.CurrentLevel));
                gameEndDialog.ShowDialog(true);
            }
        }
    }

    public void ResetQuesPanel()
    {
        questionText.text = "";
        foreach (Button item in answerButtons)
        {
            item.GetComponentInChildren<Text>().text = "";
        }
        foreach (Button item in answerButtons)
        {
            item.tag = "Untagged";
        }

        foreach (Button item in answerButtons)
        {
            item.GetComponent<Image>().sprite = buttonStates[0];
        }
    }

    public void StartCountDown()
    {
        timeCounting.SetActive(true);
        StartCoroutine("TimeCountDown");
    }

    public void StopCountDown()
    {
        timeCounting.SetActive(false);
        StopCoroutine("TimeCountDown");
    }

    public IEnumerator ShowCurrentMoney()
    {
        CurrentBountyDialog.GetComponentInChildren<Text>().text = BonusMilestone.GetCurrentMoneyLevel(GameManager.Ins.CurrentLevel);
        CurrentBountyDialog.SetActive(true);
        float timeToClose = 2f;
        while (timeToClose >= 0)
        {
            timeToClose--;
            yield return new WaitForSeconds(1);
        }
        CurrentBountyDialog.SetActive(false);
    }

    IEnumerator TimeCountDown()
    {
        int time = 60;
        timeCounting.GetComponentInChildren<Text>().text = time.ToString();
        while (time >= 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timeCounting.GetComponentInChildren<Text>().text = time.ToString();
        }
        if (!GameManager.Ins.PlayerHasAnswered)
        {
            GameManager.Ins.IsGameOver = true;
        }
        timeCounting.SetActive(false);
    }


    //Settings UI

    public void OpenSettingsUI()
    {
        SettingsUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        SettingsUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(2);
    }

}
