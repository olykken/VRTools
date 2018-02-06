using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spammer : MonoBehaviour {
	
	// Just spamms the logs, usefull for some debug situations
	void Update () {
        Debug.Log("log");
        Debug.LogWarning("Warn");
        Debug.LogError("error");
	}
}
