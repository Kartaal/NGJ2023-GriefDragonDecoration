using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueChoice : MonoBehaviour
{
    [Multiline] public string dragonText;
    public GameObject dragonTMP;

    [Space(5)]
    [Multiline] public string choiceAText;
    public TextMeshProUGUI choiceATMP;
    public int choiceAValue;
    public GameObject choiceA;
    [Multiline] public string nextDragonA;

    [Space(5)]
    [Multiline] public string choiceBText;
    public TextMeshProUGUI choiceBTMP;
    public int choiceBValue;
    public GameObject choiceB;
    [Multiline] public string nextDragonB;

    [Space(5)]
    [Multiline] public string choiceCText;
    public TextMeshProUGUI choiceCTMP;
    public int choiceCValue;
    public GameObject choiceC;
    [Multiline] public string nextDragonC;

    public DialogueChoice nextChoice;
    
    private string nextDragonText = "";

    private void Awake()
    {
        choiceATMP.text = choiceAText;
        choiceBTMP.text = choiceBText;
        choiceCTMP.text = choiceCText;
    }


    public void DisplayUIElements()
    {
        dragonTMP.SetActive(true);
        choiceA.SetActive(true);
        choiceB.SetActive(true);
        choiceC.SetActive(true);
    }

    public void HideUIElements()
    {
        dragonTMP.SetActive(false);
        choiceA.SetActive(false);
        choiceB.SetActive(false);
        choiceC.SetActive(false);
    }

    public void ApplyChoice(string c)
    {
        Debug.Log($"Applying choice {c}");
        
        switch (c)
        {
            case "a":
                DialogueManager.instance.ApplyScoreChange(choiceAValue);
                nextDragonText = nextDragonA;
                break;
            case "b":
                DialogueManager.instance.ApplyScoreChange(choiceBValue);
                nextDragonText = nextDragonB;
                break;
            case "c":
                DialogueManager.instance.ApplyScoreChange(choiceCValue);
                nextDragonText = nextDragonC;
                break;
            default:
                return;
        }
        
        
        if (nextChoice)
        {
            nextChoice.InitChoice(nextDragonText);             
        }
        else
        {
            Debug.Log($"Going to last dragon text");
            HideUIElements();
            UIManager.instance.DisplayLastDragonText(nextDragonText);
        }
    }

    private void InitChoice(string newDragonText)
    {
        Debug.Log($"Running init for {gameObject.name}");
        dragonText = newDragonText;
        dragonTMP.GetComponent<TextMeshProUGUI>().text = dragonText;
        DialogueManager.instance.NextDialogue();
    }
}
