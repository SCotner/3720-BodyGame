using UnityEngine;
using System.Collections;

public class EnemyAITest : MonoBehaviour {


	public Transform target; //the enemy's target
	public float moveSpeed =3f; //move speed
	public float rotationSpeed = 3f; //speed of turning
	private float range =100f;
	private float range2 =100f;
	private float stop = 0f;
	private Transform myTransform; //current transform data of this enemy

	void Awake()
	{
		myTransform = transform; //cache transform data for easy access/preformance
	}
	
	void Start()
	{
		target = GameObject.FindWithTag("Player").transform; //target the player
		
	}
	
	void Update () {
		//rotate to look at the player
		var distance = Vector3.Distance (myTransform.position, target.position);
		if (distance <= range2 && distance >= range) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                        Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		} else if (distance <= range && distance > stop) {


			//move towards the player
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                        Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);


			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

		} else if (distance <= stop) {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation,
			                                        Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
		}
	}
}
