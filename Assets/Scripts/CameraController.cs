using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Main;
    [SerializeField] private CinemachineVirtualCamera Finish;
    
    public static CameraController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SwapCam()
    {
        Main.m_Priority--;
        Finish.m_Priority++;
    }
}
