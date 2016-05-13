using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour
{
	public int TimeMin = 5;
	public int TimeMax = 7;
	public AudioClip[] Clips;

	private AudioSource sound;
	private Animator[] animators;


	IEnumerator ThroughLoop()
	{
		while (true)
		{
			int randNum = Random.Range(0, animators.Length);
			animators[randNum].SetTrigger("trigger");

			randNum = Random.Range(0, Clips.Length);
			sound.clip = Clips[randNum];
			sound.Play();

			int nextSpearTime = Random.Range(TimeMin, TimeMax);

			yield return new WaitForSeconds(nextSpearTime);
		}
	}

	// Use this for initialization
	void Start ()
	{
		animators = GetComponentsInChildren<Animator>();
		sound = GetComponent<AudioSource>();

		StartCoroutine("ThroughLoop");
	}
	
	public void Pause()
	{
		StopCoroutine("ThroughLoop");
	}

	public void Restart()
	{
		StopCoroutine("ThroughLoop");
		StartCoroutine("ThroughLoop");
	}
}
