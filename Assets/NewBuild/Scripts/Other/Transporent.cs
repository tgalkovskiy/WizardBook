using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transporent : MonoBehaviour
{
    private Text This_Text;
    private Image This_Image;
    private bool Text = false;
    private bool Start = true;
    private void Awake()
    {
        if (this.GetComponent<Text>())
        {
            This_Text = this.GetComponent<Text>();
            Text = true;
        }
        else
        {
            This_Image = this.GetComponent<Image>();
        }
        
    }
    private void OnEnable()
    {
        if (Text)
        {
                StartCoroutine(c_Blinking_Text(This_Text));
        }
        else
        {
                StartCoroutine(c_Blinking_Image(This_Image));
        }
    }
    //private void Update()
    //{
        
    //    Debug.Log(Start);
    //}

    IEnumerator c_Blinking_Text(Text image)
    {
        Color c = image.color;

        float alpha = 1.0f;

        while (true)
        {
            c.a = Mathf.MoveTowards(c.a, alpha, Time.deltaTime);

            image.color = c;

            if (c.a == alpha)
            {
                if (alpha == 1.0f)
                {
                    alpha = 0.4f;
                }
                else
                    alpha = 1.0f;
            }
            yield return null;
        }
        
    }
    IEnumerator c_Blinking_Image(Image image)
    {
        Color c = image.color;

        float alpha = 1.0f;

        while (true)
        {
            c.a = Mathf.MoveTowards(c.a, alpha, Time.deltaTime);

            image.color = c;

            if (c.a == alpha)
            {
                if (alpha == 1.0f)
                {
                    alpha = 0.4f;
                }
                else
                    alpha = 1.0f;
            }
            yield return null;
        }
        
    }
}

