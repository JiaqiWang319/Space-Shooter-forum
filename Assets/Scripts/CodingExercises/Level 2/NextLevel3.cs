using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour {

    // Update is called once per frame
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
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
