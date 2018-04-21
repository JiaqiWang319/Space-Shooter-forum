using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;  
using MySql.Data;
using MySql.Data.MySqlClient; 

public class Forum_Submit_TEXT : MonoBehaviour {

	public InputField inputText;
	string constr = "server=192.168.43.239;Database=mydb;User Id=root;password=onionst";
	string inputtext;
	// Use this for initialization
	void Start () {
		
	}
	public void create_new_text () {
		
		MySqlConnection mycon = new MySqlConnection(constr);
		mycon.Open(); 
		Debug.Log("success!");
		Debug.Log(inputText.text);
		string query1 = "insert into forum(time, text) values(now()," + "'"+inputText.text+"'" + ");";
		MySqlCommand mycmd1 = new MySqlCommand(query1, mycon);
		if (mycmd1.ExecuteNonQuery() > 0)  
			Debug.Log("Create a new text success!"); 

		mycon.Close();
		SceneManager.LoadScene(3);
		
	}
	// Update is called once per frame
	void Update () {
		
	}
}
