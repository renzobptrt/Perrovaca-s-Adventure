using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{   
    //Features
    public QuestController[] quests;
    public bool[] questCompleted;

    //Quest find
    public string itemCollected;

    //Quest kill
    public string enemyKilled;

    //Dialog
    private DialogManager manager;
 
    
    void Start()
    {
        questCompleted = new bool[quests.Length];
        manager = FindObjectOfType<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestText(string questText){
        //Convirtio el texto en un array de una sola linea de texto
        string[] dialogLines = new string[]{
            questText
        };
        manager.ShowDialog(dialogLines);
    }
}
