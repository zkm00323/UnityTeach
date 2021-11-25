using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] GameObject freeLookCam;
    CinemachineFreeLook freeLookComponent;
    CinemachineVirtualCamera virtualCam;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        freeLookComponent = freeLookCam.GetComponent<CinemachineFreeLook>();
    }

    [SerializeField]
    private bool isDragging;
    void Update()
    {
        //DetectMouse();
        if (Input.GetMouseButtonDown(2))
        {
            isDragging = true;
            freeLookComponent.m_XAxis.m_MaxSpeed = 300;
            //freeLookComponent.m_YAxis.m_MaxSpeed = 0.5f;
            

        }
        if (Input.GetMouseButtonUp(2))
        {
            isDragging = false;
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
            freeLookComponent.m_YAxis.m_MaxSpeed = 0;

        }
        //zoom
        if ( Input.mouseScrollDelta.y != 0)
        {
            //freeLookComponent.m_Lens.FieldOfView
        }
    }



   
}
