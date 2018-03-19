//Created by Oliver Lykken
//Place this script on a Vive controller to enable trackpad movement
using UnityEngine;

public class SimpleTouchpadMovement : MonoBehaviour {
    
    [Tooltip("The maximum speed the play area will be moved when the touchpad is being touched at its edges.")]
    public float maxSpeed = 3f;

    [Tooltip("Assign the head of the camera rig here")]
    public Transform headSet;

    private SteamVR_Controller.Device activeController { get { return SteamVR_Controller.Input((int)trackedController.controllerIndex); } }
    private SteamVR_TrackedController trackedController;
    private Transform playArea;
    private Vector2 touchAxis;
    private float movementSpeed;//measured on Y axis of touchpad
    private float strafeSpeed;//measured on X axis of touchpad

    private void Awake()
    {
        trackedController = GetComponent<SteamVR_TrackedController>();
        playArea = GetComponentInParent<SteamVR_PlayArea>().gameObject.transform;

        //If no headset is assigned find the main camera
        if(headSet == null)
        {
            GameObject hmd = GameObject.FindGameObjectWithTag("MainCamera");
            headSet = hmd.transform;
        }
    }

    private void OnEnable()
    {
        movementSpeed = 0f;
        strafeSpeed = 0f;
        touchAxis = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (activeController.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            touchAxis = activeController.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
            SetSpeed(ref movementSpeed, touchAxis.y);
            SetSpeed(ref strafeSpeed, touchAxis.x);
            MovePlayer();
        }
    }

    private void SetSpeed(ref float speed, float input)
    {
        speed = (maxSpeed * input);
    }

    private void MovePlayer()
    {
        var movement = headSet.forward * movementSpeed * Time.deltaTime;
        var strafe = headSet.right * strafeSpeed * Time.deltaTime;
        float fixY = playArea.position.y;
        playArea.position += (movement + strafe);
        playArea.position = new Vector3(playArea.position.x, fixY, playArea.position.z);
    }
}
