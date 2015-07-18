using UnityEngine;
using System.Collections;

public class IntermissionController : MonoBehaviour {

	public string Stage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown (KeyCode.Space))
		{
			Application.LoadLevel (Stage);
		}
	}
}
