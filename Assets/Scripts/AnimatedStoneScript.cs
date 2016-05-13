using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animation))]
public class AnimatedStoneScript : MonoBehaviour 
{
	public Animation anim;

	private float posY = 0.8f;
	private float posX;
	private float scale;

	// Use this for initialization
	void Start () 
	{
		posX = Random.Range(1.4f, 3.0f);
		posX *= Random.Range(0, 2) * 2 - 1;

		scale = Random.Range(0.05f, 0.1f);
		transform.localScale = new Vector3(scale, scale, 1);

		anim = GetComponent<Animation>();
		AnimationCurve curveZ = AnimationCurve.Linear(0, 0, 1.7f, -10);
		AnimationCurve curveX = new AnimationCurve();
		curveX.AddKey(0, posX);

		AnimationCurve curveY = new AnimationCurve();
		curveY.AddKey(0, posY);

		AnimationClip clip = new AnimationClip();
		clip.legacy = true;
		clip.SetCurve("", typeof(Transform), "localPosition.x", curveX);
		clip.SetCurve("", typeof(Transform), "localPosition.y", curveY);
		clip.SetCurve("", typeof(Transform), "localPosition.z", curveZ);
		//clip.wrapMode = WrapMode.Loop;
		anim.AddClip(clip, "test");
		anim.Play("test");
		Invoke("OnDestroy", anim["test"].length);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnStop()
	{
		anim.Stop();
		CancelInvoke("OnDestroy");
	}

	void OnDestroy()
	{
		Destroy(this.gameObject);
	}
}
