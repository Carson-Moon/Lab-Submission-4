using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Singleton
    public static CameraController instance { get; private set; }

    public CinemachineVirtualCamera defaultCam;
    public CinemachineVirtualCamera meteorCam;
    private CinemachineBasicMultiChannelPerlin BigExplosionShake;
    private CinemachineBasicMultiChannelPerlin SmallExplosionShake;
    private float shaketimer;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
         BigExplosionShake = meteorCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
         SmallExplosionShake = defaultCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
    }

    private void Update() 
    {
        CamerashakeCooldown();
    } 

    public void ZoomOut()
    {
        meteorCam.Priority = 20;
        defaultCam.Priority = 9;
    }

    public void ZoomIn()
    {
        meteorCam.Priority = 9;
        defaultCam.Priority = 20;
    }

    public void BigMeteorExplosion(float intensity, float time)
    {
        BigExplosionShake.m_AmplitudeGain = intensity;
        shaketimer = time;
    }

    public void SmallMeteorExplosion(float intensity, float time)
    {
        SmallExplosionShake.m_AmplitudeGain =intensity;
        shaketimer = time;
    }

    public void CamerashakeCooldown()
    {
        if(shaketimer>0)
        {
            shaketimer -= Time.deltaTime;
            if(shaketimer<=0)
            {
                BigExplosionShake.m_AmplitudeGain = 0;
                SmallExplosionShake.m_AmplitudeGain = 0;
            }
        }
    }
}
