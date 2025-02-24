using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
     public AudioMixer audioMixer;
     //public Toggle musicToggle;

     public void SetVolume(float volume)
     {
         audioMixer.SetFloat("volume", volume);
     }

}
