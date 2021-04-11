using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBut : MonoBehaviour
{
    [SerializeField] private GameObject LoadPanel = default;

    public void ActivPanel()
    {
        LoadPanel.SetActive(true);
    }
    public void ActivWindow(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
    public void DeactivWindow(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
