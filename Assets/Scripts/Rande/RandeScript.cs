using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandeScript : MonoBehaviour
{
    public GameObject konec;
    private float _timeRemaining = 4;

    void Update()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }
        if(_timeRemaining <= 0)
        {
                konec.SetActive(true);
                Time.timeScale = 0;
        }
    }
}
