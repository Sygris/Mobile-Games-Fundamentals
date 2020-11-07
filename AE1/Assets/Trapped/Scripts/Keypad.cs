using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    private List<string> NumbersOnScreen = new List<string>();

    public Text ScreenText;
    public int MaxNumberOnScreen;
    
    public string CorrectCode;
    private string CodeOnScreen = "";

    private int CurrentNumberOnScreen = 0;

    public void Print()
    {
        if (CurrentNumberOnScreen != MaxNumberOnScreen)
        {
            ScreenText.text = "";
            CodeOnScreen = "";

            NumbersOnScreen.Add(EventSystem.current.currentSelectedGameObject.name);

            foreach (string Number in NumbersOnScreen)
            {
                CodeOnScreen += Number;
                ScreenText.text += Number;
            }
        }
    }

    public void Clear()
    {
        NumbersOnScreen.Clear();
        ScreenText.text = "";
    }

    public void CheckPin()
    {
        if (CodeOnScreen.Equals(CorrectCode))
            ScreenText.text = "PASS";
        else
        {
            ScreenText.text = "FAIL";
            NumbersOnScreen.Clear();
        }
    }
}
