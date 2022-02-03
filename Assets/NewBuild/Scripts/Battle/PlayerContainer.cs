using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] typeAttackPartical;
    public GameObject arsonPartical;
    public GameObject shildPartical;
    public GameObject timeStopPartical;
    public GameObject deleteWrongWordPartical;
    public GameObject fireAuraPartical;
    private int _numberWeapon;
    public void SetWeapon(int numberWeapon)
    {
        weapons[numberWeapon].SetActive(true);
        _numberWeapon = numberWeapon;
    }

    public void OnParticalFromMagicAttack()
    {
        typeAttackPartical[_numberWeapon].SetActive(true);
    }
    public void OffParticalFromMagicAttack()
    {
        typeAttackPartical[_numberWeapon].SetActive(false);
    }
}
