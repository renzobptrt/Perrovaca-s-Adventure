using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{   

    //One Dialog Line
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public bool dialogActive;   

    //Array of Dialog lines
    public string[] dialogLines;
    public int currentDialogLine;

    //Outside
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Space)){
            currentDialogLine ++;
        }
        if(currentDialogLine >= dialogLines.Length){
            dialogActive = false;
            dialogBox.SetActive(false);
            currentDialogLine = 0;
            playerController.playerTalking = false;
        }else{
            dialogText.text = dialogLines[currentDialogLine];
        }
    }

    public void ShowDialog(string[] linesText){
        dialogActive = true;
        dialogBox.SetActive(true);
        currentDialogLine = 0;
        dialogLines = linesText;
        playerController.playerTalking = true;
    }
}
