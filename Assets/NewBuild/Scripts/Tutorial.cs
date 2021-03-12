using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image MainImage = default;
    [SerializeField] private Sprite[] Sprite = default;
    [SerializeField] private GameObject ButtomBack = default;
    private int Number = 0;
    private void OnEnable()
    {
        MainImage.sprite = Sprite[Number];
        ButtomBack.SetActive(false);
    }
    public void NextImage()
    {
        ButtomBack.SetActive(true);
        if (Number < Sprite.Length-1)
        {
            Number += 1;
            MainImage.sprite = Sprite[Number];
        }
        else
        {
            Number = 0;
            this.gameObject.SetActive(false);
        }


    }
    public void BackImage()
    {
        if (Number > 0)
        {
            Number -= 1;
            MainImage.sprite = Sprite[Number];
            
        }
    }

    public void Skip()
    {
        this.gameObject.SetActive(false);
    }
}
