using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.FootballGameEngine_Indie_.Scripts.Utilities.Misc
{
    public class PersistentGameObject : MonoBehaviour
    {
        private void Awake()
        {
            try
            {
                DontDestroyOnLoad(this);
                //GameObject.FindGameObjectWithTag("Pers").SetActive(true);
                //Destroy(this.gameObject);
            }
            catch
            {
                
            }
        }
        private void OnLevelWasLoaded(int level)
        {
            if (level == 2)
            {
                Debug.Log("Load penalty and destroy");
                Destroy(this.gameObject);
            }
        }
    }
}
