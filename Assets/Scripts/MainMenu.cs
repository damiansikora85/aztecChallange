using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void OnStartClick()
	{
		SceneManager.LoadScene("Level2");
	}
}
