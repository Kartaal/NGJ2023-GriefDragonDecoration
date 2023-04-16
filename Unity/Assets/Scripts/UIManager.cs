using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public GameObject canvas;
    public TextMeshProUGUI textArea;
    public TextMeshProUGUI lastDragonTextArea;

    [Multiline] public string dragonConfrontationText;
    [Multiline] public string winText;
    [Multiline] public string loseText;

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
    }


    public void DisplayText(string text)
    {
        DisplayCanvas();

        textArea.text = text;
        textArea.gameObject.SetActive(true);
    }

    public void DisplayLastDragonText(string text)
    {
        DisplayCanvas();

        lastDragonTextArea.text = text;
        lastDragonTextArea.gameObject.SetActive(true);
    }

    public void DisplayCanvas()
    {
        canvas.SetActive(true);
    }

    public void HideCanvas()
    {
        canvas.SetActive(false);
    }

    public void DisplayConfrontingDragon()
    {
        DisplayText(dragonConfrontationText);
    }

    public void DisplayEndText()
    {
        if (DialogueManager.instance._score > 0)
        {
            DisplayWinText();
        }
        else
        {
            DisplayLoseText();
        }
        
        lastDragonTextArea.gameObject.SetActive(false);
    }

    public void DisplayWinText()
    {
        DisplayText(winText);
    }

    public void DisplayLoseText()
    {
        DisplayText(loseText);
    }
}
