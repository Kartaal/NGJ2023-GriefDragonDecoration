using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }
    
    public int _score = 0;
    private int choiceIndex = 0;

    public List<DialogueChoice> editorChoices;
    private List<DialogueChoice> choices;

    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        choices = editorChoices;
    }

    public void ApplyScoreChange(int val)
    {
        _score += val;
    }

    public void StartDialogue()
    {
        choices[0].DisplayUIElements();
    }

    public void NextDialogue()
    {
        Debug.Log($"Starting next dialogue method from index {choiceIndex}");
        foreach (var choice in choices)
        {
            choice.gameObject.SetActive(false);
        }
        
        choices[++choiceIndex].gameObject.SetActive(true);
    }
}
