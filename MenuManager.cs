//Created by Oliver Lykken
//Toggles a menu item and a SteamVR laser pointer
using UnityEngine;

public class MenuManager : MonoBehaviour {

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;
    private ulong menuButton = SteamVR_Controller.ButtonMask.ApplicationMenu;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private SteamVR_LaserPointer lzrPtr;

    private void Awake()
    {
        lzrPtr.enabled = false;
    }

    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        if (menu == null)
        {
            menu = GameObject.Find("Menu");
        }
        menu.SetActive(false);
    }

    // Toggles the menu
    void Update()
    {

        switch (menu.activeInHierarchy)
        {
            case false:
                if (controller.GetPressDown(menuButton))
                {
                    menu.SetActive(true);
                    lzrPtr.enabled = true;
                    lzrPtr.pointer.SetActive(true);
                    Debug.Log("Menu Open");
                }
                break;
            case true:
                if (controller.GetPressDown(menuButton))
                {
                    menu.SetActive(false);
                    lzrPtr.enabled = false;
                    lzrPtr.pointer.SetActive(false);
                    Debug.Log("Menu Closed");
                }
                break;
        }
    }
}
