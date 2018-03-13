using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Loader : MonoBehaviour {

	public static int levelToLoad{
		get{ 
			return PlayerPrefsManager.levelToload;
		}
		set{
			PlayerPrefsManager.levelToload = value;
		}
	} 

	public float delay = 3f;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		StartCoroutine(LoadLevel(delay));

		Resources.UnloadUnusedAssets();
		System.GC.Collect();
		System.GC.WaitForPendingFinalizers();
	}
	
	IEnumerator LoadLevel (float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(levelToLoad);
	}
}
