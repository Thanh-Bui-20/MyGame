using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattlerHud : MonoBehaviour
{
    //Source of code: Brackeys - "Turn-based Combat in Unity"
    //link to tutorial video: https://www.youtube.com/watch?v=_1pz_ohupPs&t=1016s
    
    public Text nameText;
    public Text levelText;
    public Slider HPSlider;

    public void SetBattleHud(Unit characterUnit)
    {
        nameText.text = characterUnit.characterName;
        levelText.text = "Level " + characterUnit.characterLevel;
        HPSlider.maxValue = characterUnit.maxHP;
        HPSlider.value = characterUnit.currentHP;
    }

    public void SetHPValue(int HP)
    {
        HPSlider.value = HP;
    }
}
