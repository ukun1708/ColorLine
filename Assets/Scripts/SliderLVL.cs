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

        var pros = PathMover.Singleton.puthLVL;

        slider.value = PathMover.Singleton.puthLVL * slider.value;
    }
}
