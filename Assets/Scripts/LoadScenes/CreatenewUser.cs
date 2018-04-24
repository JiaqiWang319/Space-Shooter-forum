using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Data;  
using MySql.Data;
using MySql.Data.MySqlClient; 

public class CreatenewUser : MonoBehaviour {
	public InputField userName;
	public InputField userPassword;
	public Text userexist;
	string constr = "server= sql9.freemysqlhosting.net;Database=sql9234326;User Id=sql9234326;password=n29lCjJ5fj";
	string username;
	string password;
	// Use this for initialization
	private void Start () {
		username = null;
		password = null;
	}
	public void create_new_user () {
		MySqlConnection mycon = new MySqlConnection(constr);
		mycon.Open(); 
		string count = "select count(*) from Player where Username=" + "'" + userName.text + "';";
		MySqlDataAdapter dataAdapter1 = new MySqlDataAdapter(count, mycon);
		DataSet ds2 = new DataSet ();
		dataAdapter1.Fill (ds2);
		string count_num = (ds2.Tables [0].Rows [0] [0]).ToString();
		int num = int.Parse (count_num);
		if (num == 0) {
			string query = "insert into Player(Username, Password) values(" + "'" + userName.text + "'" + ", " + "'" + userPassword.text + "'" + ");";
			MySqlCommand mycmd = new MySqlCommand (query, mycon);
			if (mycmd.ExecuteNonQuery () > 0) {
				Debug.Log ("Create a new user success!"); 
				LoadLevelMenu ();
			}
			LoadLevelMenu ();//this should be delete when the database is on;
			mycon.Close ();
		} else {
			Debug.Log ("Username exists!");
			userexist.text="Username exists!";
		}

	
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void LoadLevelMenu()
	{

		if (userName.text != null)// && userPassword.text != null)
		{
			SceneManager.LoadScene(1);
		}
	}
}
