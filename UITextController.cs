using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextController : MonoBehaviour
{
    public Text textComponent;

    private void Start()
    {
        textComponent.text = "Press M to roll dice";
    }

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}

