using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderLVL : MonoBehaviour
{
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = PathMover.Singleton.puthLVL / PathMover.Singleton.m_Path.PathLength;
    }
}
