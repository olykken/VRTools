//Based on FusedVR
//Modified by Oliver Lykken
//Uses Steam Controller to draw by creating line renderer GameObjects, this is not very optimized

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLineDrawer : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;

    private LineRenderer currLine;
    private int numClicks = 0;

    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject lr = new GameObject();
            currLine = lr.AddComponent<LineRenderer>();
            currLine.startWidth=0.1f;
            currLine.endWidth=0.1f;
            numClicks = 0;
        }
        else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            currLine.positionCount = numClicks + 1;
            currLine.SetPosition(numClicks, trackedObj.transform.position);
            numClicks++;
        }
    }
}
