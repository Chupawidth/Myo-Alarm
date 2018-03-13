using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : SingletonBehaviour<GUIController>
{

	#region Panel

	public GameObject panelDebugLog;
    public GameObject panelAlarm;
	#endregion

	#region publicParameter

	public bool isShowLog;

	#endregion

	#region PrivateParameter

	private static bool objCreated = false;

	#endregion

	#region LifeCycle

	void Awake ()
	{
		if (!objCreated) {
			objCreated = true;
			_instance = this;
			DontDestroyOnLoad (_instance);
			panelDebugLog.SetActive (isShowLog);
		} else {
			DestroyImmediate (gameObject);
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	//	void OnGUI()
	//	{
	//		if(GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
	//		{
	//			if(OnClicked != null)
	//				OnClicked();
	//		}
	//	}

	#endregion

	#region GameMethod


	public void DisableAll ()
	{
        panelAlarm.SetActive(false);
	}

	#endregion

	#region UIController


	#endregion
}
