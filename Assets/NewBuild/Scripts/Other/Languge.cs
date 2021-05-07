using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Languge : MonoBehaviour
{
    [SerializeField] private ChoiesLanguege ChoiesLanguege;
    [SerializeField] private Dropdown Lang1;
    [SerializeField] private Dropdown Lang2;

    private void Awake()
    {
        ChoiesLanguege.LoadData();
        Lang1.value = ChoiesLanguege.Languge1;
        Lang2.value = ChoiesLanguege.Languge2;
    }

    public void ferstL()
    {
        ChoiesLanguege.Languge1 = Lang1.value;
        ChoiesLanguege.SaveData();
    }

    public void secondL()
    {
        ChoiesLanguege.Languge2 = Lang2.value;
        ChoiesLanguege.SaveData();
    }
}
