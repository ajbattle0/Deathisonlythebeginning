using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ClickSound;
    public AudioClip HoverSound;
    public AudioSource GameSounds;

    public void HoverOversound()
    {
        GameSounds.PlayOneShot(HoverSound);
    }
    public void Clickbuttonsound()
    {
        GameSounds.PlayOneShot(ClickSound);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
