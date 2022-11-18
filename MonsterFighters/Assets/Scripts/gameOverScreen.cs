using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameOverScreen : MonoBehaviour
{
    
    public void SetupgameOver()
    {
        gameObject.SetActive(true);
       
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
