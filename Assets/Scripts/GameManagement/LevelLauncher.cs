using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLauncher : MonoBehaviour {
	public void LoadScene(string level)
	{
		SceneManager.LoadScene (level);
	}

	public void RestartScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
