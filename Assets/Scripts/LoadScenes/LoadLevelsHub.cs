using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelsHub : MonoBehaviour {

    // Update is called once per frame
    public void LoadLevelHub()
    {
        SceneManager.LoadScene(2);
    }
    /*
        public void Quit()
        {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
        }
        */
}
