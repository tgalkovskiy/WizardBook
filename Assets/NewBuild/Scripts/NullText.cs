using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullText : MonoBehaviour
{
    [SerializeField] private GameObject Pers_text;
    [SerializeField] private GameObject Eny_text;

    private void Awake()
    {
        Null_text();
    }

    public void Null_text()
    {
        Pers_text.GetComponent<TextMesh>().text = "";
        Eny_text.GetComponent<TextMesh>().text = "";

    }
}
