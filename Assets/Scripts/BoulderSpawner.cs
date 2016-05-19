using UnityEngine;
using System.Collections;

public class BoulderSpawner : MonoBehaviour
{
	public GameObject BoulderPrefab;
	public float SpawnSpeed = 1.0f;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine("SpawnCoroutine");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SetEnable(bool enable)
	{
		if(enable)
			StartCoroutine("SpawnCoroutine");
		else
			StopCoroutine("SpawnCoroutine");
	}

	IEnumerator SpawnCoroutine()
	{
		while(true)
		{
			GameObject boulder = Instantiate(BoulderPrefab);
			
			boulder.transform.SetParent(transform);
			boulder.transform.localPosition = new Vector3(Random.value*2-1, 0, 0);
			yield return new WaitForSeconds(Random.value+0.5f);
		}
	}
}
