using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IInputListener
{
	public LevelLogic Level;
	public InputManager InputManager;
	public Text TapToRestartText;

	private static GameManager instance;
	private bool gameOver;

	// Construct  
	private GameManager() 
	{
		gameOver = false;
		//TapToRestartText.gameObject.SetActive(false);
	}    
	
	//  Instance  
	public static GameManager Instance {     
		get {       
			if (instance == null)
				instance = GameObject.FindObjectOfType (typeof(GameManager)) as  GameManager;      
			return instance;    
		} 
	}

	// Use this for initialization
	void Start () 
	{
		InputManager.AddListener(Level);
		InputManager.AddListener(this);
	}

	public void ShowTapToRestart()
	{
		TapToRestartText.gameObject.SetActive(true);
	}

	public void LooseLive()
	{
		TapToRestartText.text = "Tap to restart";
		TapToRestartText.gameObject.SetActive(true);
	}

	public void LevelFinished()
	{
		SceneManager.LoadScene("Level2");
	}

	public void GameOver()
	{
		TapToRestartText.text = "Game Over";
		gameOver = true;
		TapToRestartText.gameObject.SetActive(true);
	}

	void IInputListener.OnSwipeUp()
	{

	}

	void IInputListener.OnSwipeDown()
	{

	}

	void IInputListener.OnSwipeLeft()
	{

	}

	void IInputListener.OnSwipeRight()
	{

	}

	void IInputListener.OnTouchLeft()
	{

	}

	void IInputListener.OnTouchRight()
	{

	}

	void IInputListener.OnTap()
	{
		if(gameOver)
		{
			SceneManager.LoadScene("MainMenu");
		}
		else if (TapToRestartText.IsActive())
			RestartLevel();
	}

	void RestartLevel()
	{
		TapToRestartText.gameObject.SetActive(false);
		Level.Restart();
	}

}
