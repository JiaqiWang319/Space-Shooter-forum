using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Data;  
using MySql.Data;
using MySql.Data.MySqlClient; 
public class ShowForumText : MonoBehaviour {

	public Text text1;

	string constr = "server=160.39.192.229;Database=mydb;User Id=root;password=onionst";
	//text1=newobject.GetComponent<>();
	// Use this for initialization
	void Start () {
		//text1.text = "hello \n\n"+"here!\n\n" +"how are you?\n\n";
		//Debug.Log (text1.text);
		print_forum_text ();
		text1.text="2018-04-20 17:25:41     Learn new concepts by solving fun challenges in 25+ languages addressing all the hot programming topics.\n"
			+"2018-04-20 17:26:49     In a matter of hours, discover new languages, algorithms or tricks in courses crafted by top developers.\n"
		+"2018-04-20 17:32:07     Our approach has been designed to lead advanced developers to the next level.\n"
		+"2018-04-20 17:35:41     We're smarter togethe!!Meet like-minded enthusiasts, ask for help and have your code reviewed.\n"
		+"2018-04-20 17:35:41     Compare solutions and learn tips from the best programmers.";
		
	}
	void print_forum_text(){
		MySqlConnection mycon = new MySqlConnection(constr);
		mycon.Open ();

		string query = "select time,text from forum;";
		MySqlDataAdapter dataAdapter = new MySqlDataAdapter (query, mycon);
		DataSet ds = new DataSet ();
		dataAdapter.Fill (ds);
		Debug.Log ("Get forum text success!");
		string total_text = "";
		string query2 = "select count(*) from forum;";
		MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter (query2, mycon);
		DataSet ds2 = new DataSet ();
		dataAdapter2.Fill (ds2);
		string forum_num = (ds2.Tables [0].Rows [0] [0]).ToString();
		int num = int.Parse (forum_num);
		for (int i=num-1 ; i > num - 6; i = i - 1) {
			string current_time = (ds.Tables [0].Rows [i][0]).ToString (); 
			string current_text = (ds.Tables [0].Rows [i][1]).ToString (); 
			total_text += current_time + "  :  " + current_text + "\n\n";
		}
		text1.text = total_text;
		mycon.Close ();
	}

	
	// Update is called once per frame
	void Update () {
		print_forum_text();
	}
}
