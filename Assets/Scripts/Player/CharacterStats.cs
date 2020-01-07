using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{   
    //Exp features
    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp; //how much he needs to level up

    /*More features
        hpLeveles: More health
        strengthLevels: More damage with short damage weapon
        defenseLevels: Less damage to player
    */
    public int[] hpLevels, strengthLevels, defenseLevels;

    //Outside
    private HealthManager healthManager;

    void Start(){
        healthManager = GetComponent<HealthManager>();
    }

    public void StartCharacterStats(){
        currentLevel = 0;
        currentExp = 0;
        healthManager.currentHealth = 100;
    }

    void Update()
    {   
        if(currentLevel >= expToLevelUp.Length){
            return;
        }

        if(currentExp >= expToLevelUp[currentLevel]){
            currentLevel++;
            healthManager.UpdateMaxHealth(hpLevels[currentLevel]);
        }
    }

    public void AddExperience(int exp){
        currentExp += exp;
    }
}
