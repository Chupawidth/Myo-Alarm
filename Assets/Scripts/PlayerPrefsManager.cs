using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

	#region PlayerPref

	public static int levelToload {
		get {
			return PlayerPrefs.GetInt ("levelToload", SceneManager.sceneCountInBuildSettings - 1);
		}
		set {
			PlayerPrefs.SetInt ("levelToload", value);
		}
	}

	public static string AssetBundleServerURL {
		get { 
			return PlayerPrefs.GetString ("AssetBundleServerURL", "http://192.168.62.120/bossup/AssetBundles/"); 
		}
		set { 
			PlayerPrefs.SetString ("AssetBundleServerURL", value); 
		}
	}

	#endregion


}
