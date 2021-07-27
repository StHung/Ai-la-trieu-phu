using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveDialog : Dialog
{
    public InputField nameInput;
    public void SaveNewHightScore()
    {

        if (!string.IsNullOrWhiteSpace(nameInput.text))
        {
            DataProvider.Ins.SaveNewAchievement(nameInput.text,
                                    BonusMilestone.GetCurrentMoneyLevel(GameManager.Ins.CurrentLevel),
                                    GameManager.Ins.CurrentLevel);
        }
        GameGUIManager.Ins.gameEndDialog.SetText("Thành Tích",
                              GameManager.Ins.CurrentLevel,
                              BonusMilestone.GetCurrentMoneyLevel(GameManager.Ins.CurrentLevel));
        GameGUIManager.Ins.gameEndDialog.ShowDialog(true);
        GameGUIManager.Ins.saveDialog.ShowDialog(false);
    }
}
