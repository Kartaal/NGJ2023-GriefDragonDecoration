using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public GameObject canvas;
    public TextMeshProUGUI textArea;

    [Multiline] public string dragonConfrontationText;

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
}
