using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlace = "New Place Scene";
    public string goToPlaceName;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag.Equals("Player")){
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            SceneManager.LoadScene(newPlace);
        }
    }

}
