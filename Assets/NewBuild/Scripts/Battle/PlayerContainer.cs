using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject arsonPartical;
    public GameObject shildPartical;
    public GameObject timeStopPartical;
    public GameObject deleteWrongWordPartical;
    public GameObject fireAuraPartical;

    public void SetWeapon(int numberWeapon)
    {
        weapons[numberWeapon].SetActive(true);
    }
}
