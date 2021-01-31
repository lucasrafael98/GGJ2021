using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SatisfactionBar : MonoBehaviour
{
    public Slider slider;

    public GameObject GameOverMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0)
        {
            GameOverMenu.SetActive(true);
        }
    }

    public void ChangeSlider(float variation)
    {
        slider.value += variation;
    }
}
