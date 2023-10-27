using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("MONEY")]
    public Text UI;
    public int money;

    [Header("VITALS")]
    public float curHealth;
    public float maxHealth;
    public Slider healthbar;
    public float curArmour;
    public float maxArmour;
    public Slider armourbar;
    public float curStamina;
    public float maxStamina;
    public Slider staminabar;

    public void GetMoney(int amount)
    {
        money += amount;
    }

    private void Start()
    {
        UpdateHealth(maxHealth);
        UpdateArmour(maxArmour);
        UpdateStamina(maxStamina);
    }
    private void Update()
    {
        UI.text = money.ToString();
    }
    public void EdgeCases() 
    {
        curHealth = Mathf.Clamp(curHealth,0,maxHealth);
        curArmour = Mathf.Clamp(curArmour,0,maxArmour);
        curStamina = Mathf.Clamp(curStamina,0,maxStamina);
    }

    public void UpdateHealth(float amount)
    {
        //if there is a value, use it to update the curHealth value
        curHealth += amount;
        healthbar.value = curHealth;
        //Adding the value to the curHealth like this, lets us use both positive and negative numbers
    }

    public void UpdateArmour(float amount)
    {        
        curArmour += amount;
        armourbar.value = curArmour;
    }

    public void UpdateStamina(float amount)
    {        
        curStamina += amount;
        staminabar.value = curStamina;
    }
}
