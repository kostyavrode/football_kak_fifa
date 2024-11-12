using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenaltyUI : MonoBehaviour
{

    public void GoHome()
    {
        //GameObject.FindGameObjectWithTag("Pers").SetActive(true);
        //Destroy(GameObject.FindGameObjectWithTag("Pers").gameObject);
        SceneManager.LoadScene("MainScene");
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
