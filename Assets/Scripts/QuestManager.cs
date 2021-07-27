using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    public List<Questions> questions;


    List<Questions> quests;

    Questions currentQues;

    public override void Awake()
    {
        MakeSingleton(false);
        quests = questions;
    }

    // Update is called once per frame

    public Questions GetRandomQues()
    {
        if(quests.Count > 0)
        {
            int index = Random.Range(0, quests.Count);
            currentQues = quests[index];
            quests.RemoveAt(index);
        }

        return currentQues;
    }

    public string GetAnsOfCurrentQuest()
    {
        return currentQues.CorrectAnswwer;
    }
}
