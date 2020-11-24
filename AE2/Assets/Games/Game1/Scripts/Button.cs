using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int MaxTapCount = 3;
    private int TapCount;
    
    public Sprite ButtonRed;
    public Sprite ButtonActive;
    public Sprite ButtonDefault;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 TouchPosition = new Vector2(Position.x, Position.y);

                var Hit = Physics2D.OverlapPoint(TouchPosition);

                if (Hit)
                {
                    if (Hit.transform == transform)
                    {
                        TapCount++;
                        StartCoroutine(Tap());
                    }
                }
            }
        }

        if (TapCount == MaxTapCount)
        {
            StartCoroutine(Pass());
        }
    }

    IEnumerator Tap()
    {
        spriteRenderer.sprite = ButtonActive;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.sprite = ButtonDefault;
    }

    IEnumerator Pass()
    {
        spriteRenderer.sprite = ButtonRed;

        yield return new WaitForSeconds(0.5f);
        
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel();
        
        //GameObject.Find("Tip").SetActive(false);
    }

}
