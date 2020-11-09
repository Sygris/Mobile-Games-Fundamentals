using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    private List<string> NumbersOnScreen = new List<string>();

    public Image Bulb;
    public Text ScreenText;
    public int MaxNumberOnScreen;

    public string CorrectCode;
    private string CodeOnScreen = "";

    private bool IsInputLocked = false;
    private int CurrentNumberOnScreen = 0;

    public void PlayBeep()
    {
        SoundEffectsManager.SFXManager.PlaySFX(SoundEffectsManager.SFXType.Beep);
    }

    public void Print()
    {
        if (!IsInputLocked)
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
    }

    public void Clear()
    {
        if (!IsInputLocked)
        {
            NumbersOnScreen.Clear();
            ScreenText.text = "";
        }
    }

    public void CheckPin()
    {
        if (CodeOnScreen.Equals(CorrectCode))
            Pass();
        else
            Fail();

        StartCoroutine(Reset(1f));
    }

    void Pass()
    {
        SoundEffectsManager.SFXManager.PlaySFX(SoundEffectsManager.SFXType.Correct);

        StartCoroutine(LerpColor(Bulb.color, Color.green, 1f));

        ScreenText.text = "PASS";

    }

    void Fail()
    {
        SoundEffectsManager.SFXManager.PlaySFX(SoundEffectsManager.SFXType.Incorrect);
        StartCoroutine(LerpColor(Bulb.color, Color.red, 1f));

        ScreenText.text = "FAIL";

    }

    IEnumerator Reset(float delay)
    {
        IsInputLocked = !IsInputLocked;

        yield return new WaitForSeconds(delay);

        IsInputLocked = !IsInputLocked;

        Bulb.color = Color.gray;
        ScreenText.text = "";

        NumbersOnScreen.Clear();
    }

    IEnumerator LerpColor(Color From, Color To, float duration)
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / duration;
            Bulb.color = Color.Lerp(From, To, t);
            yield return null;
        }
    }
}
