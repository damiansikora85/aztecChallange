using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class FlashingText : MonoBehaviour
{
	Text flashingText;
	// Use this for initialization
	void Start ()
	{
		flashingText = GetComponent<Text>();
		StartCoroutine("Flashing");
		//flashingText.color = Color.red;
	}
	
	IEnumerator Flashing()
	{
		while (true)
		{
			flashingText.color = Color.black;
			yield return new WaitForSeconds(.5f);
			flashingText.color = Color.white;
			yield return new WaitForSeconds(.5f);
		}
	}
}
