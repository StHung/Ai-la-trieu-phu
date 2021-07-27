using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialog : MonoBehaviour
{
    public void ShowDialog(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

}
