using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip clickBackClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip groundedClip;
    [SerializeField] private AudioClip finishedClip;
    [SerializeField] private AudioClip gameOverClip;

    public void PlayClickClip()
    {
        sfxSource.PlayOneShot(clickClip);
    }
    
    public void PlayClickBackClip()
    {
        sfxSource.PlayOneShot(clickBackClip);
    }
    
    public void PlayJumpClip()
    {
        sfxSource.PlayOneShot(jumpClip);
    }
    
    public void PlayGroundedClip()
    {
        sfxSource.PlayOneShot(groundedClip);
    }
}
