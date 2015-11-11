using UnityEngine;
using System.Collections;

public class MainMenuControllers : MonoBehaviour {

	public void Play() {
		Application.LoadLevel ("1");
	}

	public void Exit() {
		Application.Quit ();
	}

	public void Options() {
		//TODO: Code another UI Menu for the options screen
	}
}
