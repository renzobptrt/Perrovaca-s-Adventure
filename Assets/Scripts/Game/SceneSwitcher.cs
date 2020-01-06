using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{   

    public GameObject guiInGame;
    public GameObject player;

    public void  PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void Back(){
        guiInGame.SetActive(true);
        player.SetActive(true);
        player.GetComponent<HealthManager>().currentHealth = 220;
        SceneManager.LoadScene("Main Scene");

    }

    public void GameOver(){
        player.SetActive(false);
        guiInGame.SetActive(false);
        SceneManager.LoadScene("GameOverScene");
    }
}
