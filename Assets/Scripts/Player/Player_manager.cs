using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_manager : MonoBehaviour
{
	#region Singleton

	public static Player_manager instance;

	private void Awake()
	{
		instance = this;
	}
	#endregion

	public GameObject Player;

	public void KillPlayer()
	{

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

	}
}
