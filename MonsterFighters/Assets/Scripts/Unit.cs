using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string characterName;
    public string characterLevel;
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage(int characterDamage)
    {
        currentHP -= characterDamage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
     public void HealPlayer(int healAmount)
    {
        currentHP += healAmount;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }
}
