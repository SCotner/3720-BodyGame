using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private int scoreValue = 10;
	private GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();

		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//Debug.Log (other.name);
		if (other.tag == "Boundary") {
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			gameController.GameOver ();
		}

		else if (tag.Contains("Virus") && other.tag == "Anti-Virus")
		{
			gameController.AddCountdown (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		else if (tag.Contains ("Infection") && other.tag == "Antibiotic") {
			gameController.AddCountdown (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
