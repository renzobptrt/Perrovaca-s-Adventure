using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{   

    public int currentLevel;
    public int currentExp;
    public int[] expToLevelUp;

    void Update()
    {   
        if(currentLevel >= expToLevelUp.Length){
            return;
        }

        if(currentExp >= expToLevelUp[currentLevel]){
            currentLevel++;
        }
    }

    public void AddExperience(int exp){
        currentExp += exp;
    }
}
