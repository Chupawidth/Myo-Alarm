using UnityEngine;
using System.Collections;

public class EventManager : SingletonBehaviour<EventManager>
{

	#region Parameter

	private static bool objCreated = false;

	public delegate void StatusChange (string message);

	public static event StatusChange OnStatusChange;

	#endregion

	#region LifeCycle

	void Awake ()
	{
		if (!objCreated) {
			objCreated = true;
			_instance = this;
			DontDestroyOnLoad (_instance);
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

	#endregion

	#region GameMethod

	public void ChangeStatus (string message)
	{
		if (OnStatusChange != null)
			OnStatusChange (message);
	}

	#endregion
}
