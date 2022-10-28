using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBattle : MonoBehaviour
{
    private Animator characterAnim;
    private void Awake()
    {
        characterAnim = GetComponent<Animator>();

    }

    private void Start()
    {
         

            
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            characterAnim.SetBool("Attack", true);
        } 
    }

}
