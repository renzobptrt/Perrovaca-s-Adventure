using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemManager : MonoBehaviour
{   
    public TextMeshProUGUI gemText;
    public int currentGem;
    private const string gemKey = "CurrentGem";

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(gemKey)){
            currentGem = PlayerPrefs.GetInt(gemKey);
        }else{
            currentGem = 0;
            PlayerPrefs.SetInt(gemKey,0);
        }
        gemText.text = currentGem.ToString();
    }

    public void AddGem(int gemCollected){
        currentGem += gemCollected;
        PlayerPrefs.SetInt(gemKey, currentGem);
        gemText.text = currentGem.ToString();
    }
}
