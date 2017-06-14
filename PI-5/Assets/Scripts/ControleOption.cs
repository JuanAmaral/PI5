using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleOption : MonoBehaviour {

	public void BackToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}
}
