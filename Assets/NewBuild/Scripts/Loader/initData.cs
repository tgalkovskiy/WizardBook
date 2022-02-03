
using UnityEngine;

public class initData : MonoBehaviour
{
    public GameObject prefab;
    public bool isInit;
    private void Awake()
    {
        if(!isInit) return;
        Instantiate(prefab);
    }
}
