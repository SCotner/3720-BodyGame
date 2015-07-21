using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Canvas exitMenu;

	public Button exitButton;

	public Button playButton;

	// Use this for initialization
	void Start () {

		exitMenu = exitMenu.GetComponent<Canvas> ();
		exitButton = exitButton.GetComponent<Button> ();
		playButton = playButton.GetComponent<Button> ();


		exitMenu.enabled = false;
	
	}
	
	public void ExitPressed(){
		Debug.Log ("ExitPressed");
		exitMenu.enabled = true;
		playButton.enabled = false;
		exitButton.enabled = false;

	}
	public void NoPressed()
	{
		exitMenu.enabled = false;
		playButton.enabled = true;
		exitButton.enabled = true;
	}
	public void YesPressed()
	{
		Application.Quit ();
	}
	public void StartLevelPressed()
	{
		Debug.Log ("PlayPressed");
		Application.LoadLevel (1);
	}
}
