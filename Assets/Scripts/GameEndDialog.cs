using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEndDialog : Dialog
{
    public Text tittleText;
    public Text achiementText;
    public Text prizeMoneyText;
    public void SetText(string tittle, int numberOfQues, string prizeMoney)
    {
        tittleText.text = tittle;
        achiementText.text = "Bạn đã trả lời xuất sắc " + numberOfQues + " câu hỏi";
        prizeMoneyText.text = "Phần thưởng: " + prizeMoney + " VNĐ";
    }
}
