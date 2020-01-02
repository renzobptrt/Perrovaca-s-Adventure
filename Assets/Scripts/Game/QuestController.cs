using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{   
    //Features
    public int questID;     //Unique quest
    private QuestManager manager;
    public string startText, completeText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartQuest(){
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }

    public void CompleteQuest(){
        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        //Para permitir que solo se pueda realizar una sola vez la quest
        gameObject.SetActive(false);
    }
}
