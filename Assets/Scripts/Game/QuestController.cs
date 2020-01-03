using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{   
    //Features
    public int questID;     //Unique quest
    public int experience;
    private QuestManager manager;
    private CharacterStats player;
    public string startText, completeText;

    //Quest Item
    public bool needsItem;
    public string itemNeeded;

    //Quest Kill Enemy
    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    private int enemiesKilled;

    // Update is called once per frame
    void Update()
    {
        if(needsItem && manager.itemCollected.Equals(itemNeeded)){
            manager.itemCollected = null;
            CompleteQuest();
        }
        if(needsEnemy && manager.enemyKilled.Equals(enemyName)){
            manager.enemyKilled = null;
            enemiesKilled++;
            if(enemiesKilled >= numberOfEnemies){
                CompleteQuest();
            }
        }
    }

    public void StartQuest(){
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }

    public void CompleteQuest(){
        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        player = FindObjectOfType<CharacterStats>();
        player.AddExperience(experience);
        //Para permitir que solo se pueda realizar una sola vez la quest
        gameObject.SetActive(false);
    }
}
