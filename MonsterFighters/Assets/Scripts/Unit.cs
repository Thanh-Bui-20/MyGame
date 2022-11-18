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

    //Source of code: Brackeys - "Turn-based Combat in Unity"
    //link to tutorial video: https://www.youtube.com/watch?v=_1pz_ohupPs&t=1016s
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
