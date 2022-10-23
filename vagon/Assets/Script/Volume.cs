using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] Slider sliderVolume;

    public void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("Volume");
    }

    public void Change()
    {
        PlayerPrefs.SetFloat("Volume",sliderVolume.value);
    }
}
