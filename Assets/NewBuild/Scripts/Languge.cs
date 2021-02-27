using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languge : MonoBehaviour
{
    [SerializeField] private ChoiesLanguege ChoiesLanguege;
    [SerializeField] private Dropdown Lang1;
    [SerializeField] private Dropdown Lang2;

    private void Update()
    {
        ChoiesLanguege.Languge1 = Lang1.value;
        ChoiesLanguege.Languge2 = Lang2.value;
    }
    
}
