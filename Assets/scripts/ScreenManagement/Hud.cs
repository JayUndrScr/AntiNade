using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Artillery weaponry;
    public Image weaponIcon;
    public Sprite[] icons;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(weaponry._state == State.Starter)
        {
            weaponIcon.sprite = icons[0];
        }
        if (weaponry._state == State.Burst)
        {
            weaponIcon.sprite = icons[1];
        }
        if (weaponry._state == State.Spread)
        {
            weaponIcon.sprite = icons[2];
        }
        if (weaponry._state == State.Bomb)
        {
            weaponIcon.sprite = icons[3];
        }
        if (weaponry._state == State.Rail)
        {
            weaponIcon.sprite = icons[4];
        }
    }
}
