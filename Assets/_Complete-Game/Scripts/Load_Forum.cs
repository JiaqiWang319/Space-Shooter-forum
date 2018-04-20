using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;  
using MySql.Data;
using MySql.Data.MySqlClient; 

public class Load_Forum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void LoadForum()
	{

			SceneManager.LoadScene(3);


	}
	public void QuitForum()
	{

		SceneManager.LoadScene(2);


	}
	// Update is called once per frame
	void Update () {
		
	}
}
