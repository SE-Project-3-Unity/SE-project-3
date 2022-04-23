using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
	public void LoadMainScene()
	{
		SceneManager.LoadScene("SampleScene");
	}
	
	public void QuitScene()
	{
		Application.Quit();
		SceneManager.LoadScene("StartPage");
	}
	public void HistoryScene()
	{
		SceneManager.LoadScene("History");
	}
	public void backToMenu()
	{
		SceneManager.LoadScene("StartPage");
	}
}
