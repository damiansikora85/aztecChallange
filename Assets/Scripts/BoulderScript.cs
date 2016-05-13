using UnityEngine;
using System.Collections;

public class BoulderScript : MonoBehaviour
{
	public float Speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position -= new Vector3(0, Time.deltaTime * Speed, 0);
	}
}
