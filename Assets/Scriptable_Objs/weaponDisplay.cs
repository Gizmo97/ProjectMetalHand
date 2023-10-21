using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponDisplay : MonoBehaviour
{
    public Weapon weapon;

    public Text nameText;
    public Text subNameText;
    public Text descriptionText;
    public Slider currentXp;
    public Slider xpToNextLevel;
    public Text levelText;
    public Text damageText;
    public Text rangeText;
    public Text currentAmmoText;
    public Image icon;

    void Update()
    {
        //name
        //subName
        //description
        //currentXp
        //xpToNextLevel
        levelText.text = weapon.level.ToString() + "V";
        //damage
        //range
        currentAmmoText.text = weapon.currentAmmo.ToString() + "/" + weapon.maxAmmo.ToString();
        icon.sprite = weapon.picture;
    }
}
