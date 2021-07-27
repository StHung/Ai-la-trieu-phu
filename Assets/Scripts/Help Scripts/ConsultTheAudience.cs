using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConsultTheAudience : Help
{
    public List<AnswerColumn> columns;
    public override void UseHelp()
    {
        if (!GameManager.Ins.IsGameOver && !GameManager.Ins.PlayerHasAnswered)
            StartCoroutine(WaitResult());
    }

    IEnumerator WaitResult()
    {
        helpDialog.SetActive(true);
        AudioController.Ins.StopBgMusic();
        AudioController.Ins.PlayAskAudienceMusic();
        yield return new WaitForSeconds(5f);

        List<Button> existingAnswers = new List<Button>();

        foreach (Button item in GameGUIManager.Ins.answerButtons)
        {
            if (!string.IsNullOrWhiteSpace(item.GetComponentInChildren<Text>().text))
            {
                existingAnswers.Add(item);
            }
        }
        if (existingAnswers.Count == 4)
        {
            foreach (Button item in existingAnswers)
            {
                if (item.tag.Equals("RightAnswer"))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        if ((item.GetComponentsInChildren<Text>()
                                .GetValue(item.GetComponentsInChildren<Text>().Length - 1) as Text)
                                .text.Contains(columns[i].ColumnName.text))
                        {
                            columns[i].tag = "RightAnswer";

                            AnswerColumn tempCol = columns[i];
                            columns[i] = columns[0];
                            columns[0] = tempCol;
                        }
                    }
                }
            }
            int totalPercent = 100;

            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].tag.Equals("RightAnswer"))
                {
                    int percentOfRightAns = Random.Range(25, totalPercent) + 1;
                    columns[i].PercentText.text = percentOfRightAns.ToString() + "%";
                    columns[i].ColumnSlider.value = percentOfRightAns;
                    totalPercent -= percentOfRightAns;
                }
                else if (i != columns.Count - 1)
                {
                    int randPercent = Random.Range(0, totalPercent);
                    columns[i].PercentText.text = randPercent.ToString() + "%";
                    columns[i].ColumnSlider.value = randPercent;
                    totalPercent -= randPercent;
                }
                else
                {
                    columns[i].PercentText.text = totalPercent.ToString() + "%";
                    columns[i].ColumnSlider.value = totalPercent;
                }
            }
        }
        else
        {
            // this cols represent for all answer buttons which are not removed answer. 
            List<AnswerColumn> cols = new List<AnswerColumn>();
            foreach (Button item in existingAnswers)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    if ((item.GetComponentsInChildren<Text>()
                            .GetValue(item.GetComponentsInChildren<Text>().Length - 1) as Text)
                            .text.Contains(columns[i].ColumnName.text))
                    {
                        if(item.tag.Equals("RightAnswer"))
                        {
                            columns[i].tag = "RightAnswer";
                        }
                        cols.Add(columns[i]);
                    }
                }
            }
            int totalPercent = 100;
            int percentOfRightAns = Random.Range(50, totalPercent) + 1;
            totalPercent -= percentOfRightAns;
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].tag.Equals("RightAnswer"))
                {
                    cols[i].ColumnSlider.value = percentOfRightAns;
                    cols[i].PercentText.text = percentOfRightAns.ToString() + "%";
                }
                else
                {
                    cols[i].ColumnSlider.value = totalPercent;
                    cols[i].PercentText.text = totalPercent.ToString() + "%";
                }
            }
        }
        yield return new WaitForSeconds(5f);
        AudioController.Ins.PlayBgMusic();
        AudioController.Ins.StopAskAudienceMusic();
        helpDialog.SetActive(false);
        helpBtn.gameObject.SetActive(false);
    }

}
