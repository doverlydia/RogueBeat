using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    Slider difficultySlider;
    private void Start()
    {
        difficultySlider = GetComponent<Slider>();
    }
    public void SetGameDifficulty()
    {
        GameManager.instance.difficulty = (int)difficultySlider.value;
    }
}
