using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField]
    private Slider playerHealthBar;
    [SerializeField]
    private TextMeshProUGUI playerHealthText;
    [SerializeField]
    private HealthManager playerHealthManager;

    public static bool uiManagerCreated;

    void Start(){
        
    }
    // Update is called once per frame
    void Update()
    {
        //Por si subimos de nivel
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;

        playerHealthText.text = playerHealthBar.value.ToString() + "/" + playerHealthBar.maxValue.ToString();

    }

    /*void IsUIManagerCreated(){
        if(!uiManagerCreated){
            uiManagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }*/
}
