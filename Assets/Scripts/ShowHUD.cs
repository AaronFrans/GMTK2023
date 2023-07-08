using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHUD : MonoBehaviour, IInteractable
{
    [SerializeField]
    GameObject TestHUD;
    [SerializeField]
    CinemachineFreeLook freeLookCamera;

    public void Interact()
    {
        //SHOW HUD HERE
        TestHUD.SetActive(!TestHUD.activeSelf);
        freeLookCamera.enabled = !freeLookCamera.enabled;
        Debug.Log(freeLookCamera.enabled);
        if(!freeLookCamera.enabled)
        {
            freeLookCamera.m_YAxis.m_MaxSpeed = 0;
            freeLookCamera.m_XAxis.m_MaxSpeed = 0;
        }
        else
        {
            freeLookCamera.m_YAxis.m_MaxSpeed = 3;
            freeLookCamera.m_XAxis.m_MaxSpeed = 500;
        }
        PlayerData.instance.isInteracting = !PlayerData.instance.isInteracting;
    }

    public void Start()
    {
        TestHUD.SetActive(false);
    }
}
