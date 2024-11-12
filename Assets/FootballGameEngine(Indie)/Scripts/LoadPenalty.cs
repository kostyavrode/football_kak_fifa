using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPenalty : MonoBehaviour
{
    public void LoadPenaltyScene()
    {
        SceneManager.LoadScene("GoalKeeperTest");
        //GameObject.FindGameObjectWithTag("Pers").SetActive(false);
    }
}
