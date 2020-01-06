using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{   
    //Features
    public int maxHealth;
    public int currentHealth;
    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    //Used for flash player 
    private SpriteRenderer characterRenderer;

    //Enemy Features
    public int expWhenDefeated;
    public string enemyName;
    private QuestManager questManager;

    //Outside
    private SFXManager sfxManager;
    private SceneSwitcher sceneSwitcher;


    void Start()
    {
        currentHealth = maxHealth;
        characterRenderer = GetComponent<SpriteRenderer>();
        questManager = FindObjectOfType<QuestManager>();
        sfxManager = FindObjectOfType<SFXManager>();
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0 ){
            if(gameObject.tag.Equals("Enemy") || gameObject.tag.Equals("Final Enemy")){
                questManager.enemyKilled = enemyName;
                GameObject.Find("Player").
                    GetComponent<CharacterStats>().
                    AddExperience(expWhenDefeated);
            }
            if(gameObject.tag.Equals("Player")){
                sfxManager.playerDead.Play();
                sceneSwitcher.GameOver();
            }
            gameObject.SetActive(false);
        } 

        if(flashActive){
            flashCounter -= Time.deltaTime;
            if(flashCounter > flashLength * 0.80f){
                ToggleColor(false);
            } else if(flashCounter > flashLength * 0.60f){
                ToggleColor(true);
            } else if(flashCounter > flashLength * 0.40f){
                ToggleColor(false);
            } else if(flashCounter > flashLength * 0.20f){
                ToggleColor(true);
            } else if(flashCounter > flashLength * 0.0f){
                ToggleColor(false);
            } else {
                ToggleColor(true);
            }
        }
    }

    public void DamageCharacter(int damage){
        currentHealth -= damage;
        if(flashLength > 0){
            flashActive = true;
            flashCounter = flashLength;
        }
        if(gameObject.tag.Equals("Player")){
            sfxManager.playerHurt.Play();
        }
    }

    public void UpdateMaxHealth(int newMaxHealth){
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    public void ToggleColor(bool visible){
        characterRenderer.color = new Color(
            characterRenderer.color.r,
            characterRenderer.color.g,
            characterRenderer.color.b,
            (visible ? 1.0f : 0.0f) //Intensity
        );
    }
    
}
