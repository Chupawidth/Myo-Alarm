using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DebugLog : MonoBehaviour 
{
    public Text UIText;
    static private bool isUpdate = false;

    public static int Max = 20;
    public static List<string> debugLogs = new List<string>();
	
	void Start () 
    {
	
	}
	
	void Update () 
    {
        if (isUpdate)
        {
            UIText.text = "";
            for (int i = 0; i < debugLogs.Count; ++i)
            {
                UIText.text += debugLogs[i] + "\n";
            }
            isUpdate = false;
        }
	}

    static public void Add(string log)
    {
        if (debugLogs.Count >= Max)
        {
            debugLogs.RemoveAt(0);
        }

        debugLogs.Add (log);

        isUpdate = true;
    }

    public void Reset()
    {
        debugLogs.Clear();
        isUpdate = true;
    }
}
