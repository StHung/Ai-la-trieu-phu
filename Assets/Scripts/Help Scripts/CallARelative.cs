using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CallARelative : Help
{
    public Text resultText;
    
    public override void UseHelp()
    {
        if (!GameManager.Ins.IsGameOver && !GameManager.Ins.PlayerHasAnswered)
            StartCoroutine(WaitForHelpResult());
    }

    IEnumerator WaitForHelpResult()
    {

        helpDialog.SetActive(true);
        resultText.text = "Đang kết nối ...";
        yield return new WaitForSeconds(3f);
        resultText.text = "Đợi tui suy nghĩ ...";
        yield return new WaitForSeconds(3f);
        resultText.text = "Tui nghĩ đáp án là: " + QuestManager.Ins.GetAnsOfCurrentQuest();
        yield return new WaitForSeconds(2f);
        helpDialog.SetActive(false);
        helpBtn.gameObject.SetActive(false);
    }
}
