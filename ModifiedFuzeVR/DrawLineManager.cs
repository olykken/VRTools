//Based on FusedVR
//Modified by Oliver Lykken

using UnityEngine;

public class DrawLineManager : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public Material lineMaterial;

    private MeshLineRenderer currLine;
    private int numClicks = 0;
	
	void Update () {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            GameObject lr = new GameObject();
            lr.AddComponent<MeshFilter>();
            lr.AddComponent<MeshRenderer>();
            currLine = lr.AddComponent<MeshLineRenderer>();
            currLine.lineMaterial = new Material(lineMaterial);
            currLine.SetWidth(0.1f);   
        } else if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            currLine.AddPoint(trackedObj.transform.position);
            numClicks++;
        }
        else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            numClicks = 0;
            currLine = null;
        }

            if (currLine != null)
        {
            currLine.lineMaterial.color = ColorManager.Instance.GetCurrentColor();
        }
	}
}
