using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField]
    private Slider playerHealthBar;
    [SerializeField]
    private TextMeshProUGUI playerHealthText;
    [SerializeField]
    private HealthManager playerHealthManager;

    [Header("Enemy Settings")]
    //Boss Health Features 
    [SerializeField]
    private Slider bossHealthBar;
    [SerializeField]
    private TextMeshProUGUI bossHealthText;
    public HealthManager bossHealthManager;


    [Header("UI Settings")]
    public static bool uiManagerCreated;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Player
        playerHealthBar.maxValue = playerHealthManager.maxHealth;
        playerHealthBar.value = playerHealthManager.currentHealth;
        playerHealthText.text = playerHealthBar.value.ToString() + "/" + playerHealthBar.maxValue.ToString();


        //Boss
        if (bossHealthManager != null)
        {
            bossHealthBar.maxValue = bossHealthManager.maxHealth;
            bossHealthBar.value = bossHealthManager.currentHealth;
            bossHealthText.text = bossHealthBar.value.ToString() + "/" + bossHealthBar.maxValue.ToString();
        }
    }
}
