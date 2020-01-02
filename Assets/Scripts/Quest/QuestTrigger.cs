﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{   
    private QuestManager manager;
    public int questID;
    public bool startPoint, endPoint;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            Debug.Log("Entraste");
            if(!manager.questCompleted[questID]){
                if(startPoint && !manager.quests[questID].gameObject.activeInHierarchy){
                    manager.quests[questID].gameObject.SetActive(true);
                    manager.quests[questID].StartQuest();
                }
                if(endPoint && manager.quests[questID].gameObject.activeInHierarchy){
                    manager.quests[questID].CompleteQuest();
                }
            }
        }
    }


}
