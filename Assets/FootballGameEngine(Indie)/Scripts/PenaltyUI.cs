using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenaltyUI : MonoBehaviour
{

    public void GoHome()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
