using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    [SerializeField] private GameObject[] LinePoint = default;
    [SerializeField] private HP Point_Count = default;

    private void Update()
    {
        ActiveLine(Point_Count.PointBook);
    }


    private void ActiveLine(float Count)
    {
        Debug.Log(1);
        bool state = false;
        for(int i = 0; i<LinePoint.Length; i++)
        {
            if (Count >= i + 1)
            {
                state = true;
            }
            else
            {
                state = false;
            }
            LinePoint[i].SetActive(state);
        }
    }
}
