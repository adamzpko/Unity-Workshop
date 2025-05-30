using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwitch : MonoBehaviour
{
    [SerializeReference] Camera firstPersonCam;
    [SerializeReference] Camera thirdPersonCam;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonCam.enabled = true;
        thirdPersonCam.enabled = false;
    }

    void OnSwitchCamera(InputValue input)
    {
        firstPersonCam.enabled = !firstPersonCam.enabled;
        thirdPersonCam.enabled = !thirdPersonCam.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
