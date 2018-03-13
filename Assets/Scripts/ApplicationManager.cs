using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using System;

public class ApplicationManager : SingletonBehaviour<ApplicationManager>
{

	#region PublicParameter
    public GameObject myo = null;
    public InputField countdownInputField;
	#endregion

	#region PrivateParameter

	private bool objCreate = false;
    ThalmicMyo thalmicMyo;
    bool isTimeUp = false;
    float countDown = 1f;
    #endregion

	#region LifeCycle

	// Use this for initialization
	void Start ()
	{
		if (!objCreate) {
			objCreate = true;
			_instance = this;
			DontDestroyOnLoad (instance);
            thalmicMyo = myo.GetComponent<ThalmicMyo>();

		} else {
			DestroyImmediate (gameObject);
		}
	}

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
        if(isTimeUp){
            isTimeUp = false;
            StartCoroutine(OnWakeUp());
        }
    }

    #endregion

    #region PublicMethod
    public void StartCountdown(){

        GUIController.instance.DisableAll();
        double resultCountdown = 0;
        Double.TryParse(countdownInputField.text,out resultCountdown);
        AlarmClock clock = new AlarmClock(DateTime.Now.AddSeconds(resultCountdown));
        clock.Alarm += (sender, e) => Alarm();
    }
    public void Alarm()
    {
        Debug.Log("Wake up");
        GUIController.instance.panelAlarm.SetActive(true);
        isTimeUp = true;
    }

    IEnumerator OnWakeUp(){

        while(true){
            thalmicMyo.Vibrate(VibrationType.Short);
            yield return new WaitForSeconds(0.5f);
        }

    }

	#endregion

}
