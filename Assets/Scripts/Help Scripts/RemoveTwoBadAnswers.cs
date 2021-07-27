using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveTwoBadAnswers : Help
{
    public override void UseHelp()
    {
        if (!GameManager.Ins.IsGameOver && !GameManager.Ins.PlayerHasAnswered)
            StartCoroutine(RemoveTwoWrongAnswer());
    }
    IEnumerator RemoveTwoWrongAnswer()
    {
        helpDialog.SetActive(true);
        yield return new WaitForSeconds(2f);
        List<Button> wrongAnswers = new List<Button>();
        foreach (Button item in GameGUIManager.Ins.answerButtons)
        {
            if (item.tag.Equals("Untagged"))
            {
                wrongAnswers.Add(item);
            }
        }

        int randIndex = Random.Range(0, wrongAnswers.Count);

        wrongAnswers.RemoveAt(randIndex);

        helpDialog.SetActive(false);

        foreach (Button item in wrongAnswers)
        {
            item.GetComponentInChildren<Text>().text = "";
        }

        helpBtn.gameObject.SetActive(false);
    }
}
