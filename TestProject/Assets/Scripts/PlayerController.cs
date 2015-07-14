using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	public float fireRate;
	private float nextFire;

	private Camera cam;
	private Vector3 worldPos;

	private float startTime;
	public float journeyTime = 1.0f;

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

		startTime = Time.time;
		cam = Camera.main;
	}


	void Update ()
	{
		if (!gameController.getStartUp ()) {

			if (Input.GetButton ("Fire1") && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
			}
		}
	}


	/*void UpdateMouse()
	{

		float moveHorizontal = 2.0f * Input.GetAxis ("Mouse X");
		float moveVertical = 2.0f * Input.GetAxis ("Mouse Y");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);


		worldPos = cam.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,cam.nearClipPlane));
		var fracComplete = (Time.time - startTime) / journeyTime;
		transform.position = Vector3.Slerp(this.transform.position, worldPos, 5f);

		
		worldPos = cam.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,cam.nearClipPlane));
		Vector3 currentPos = Vector3.Slerp (this.transform.position, worldPos, Time.deltaTime);
		this.transform.position = new Vector3 (currentPos.x, 0, currentPos.z);

}
*/


	void UpdateKeys()
	{
		float moveHorizontal = 2.0f * Input.GetAxis ("Horizontal");
		float moveVertical = 2.0f * Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
				);
		
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
	}
	void FixedUpdate()
	{

		if (!gameController.getStartUp()) {
			if(gameController.getGameState() == "Keys")
			{
				UpdateKeys();
			} else if (gameController.getGameState() == "Mouse")
			{
//				UpdateMouse();
			}
		}
	}
}
