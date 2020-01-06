using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSwitchManager : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        sceneSwitcher = FindObjectOfType<SceneSwitcher>();
    }

    public void GoBackScene()
    {
        if (sceneSwitcher != null)
        {   
            Debug.Log("Volvemos");
            sceneSwitcher.Back();
        }
    }
}
