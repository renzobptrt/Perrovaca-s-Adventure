using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class QuestItem : MonoBehaviour
{   
    //Features
    public int questID;
    public string itemName;

    //Outside
    private QuestManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<QuestManager>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            if(manager.quests[questID].gameObject.activeInHierarchy 
            && !manager.questCompleted[questID]){
                manager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }


}
