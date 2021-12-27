using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BryleScript : MonoBehaviour
{
    public Text ScoreText;
    public Text CelkemText;
    public GameObject postup;

    private int initialScore;

    void Start() 
    {
        GameObject[] itemy = GameObject.FindGameObjectsWithTag("Item");
        initialScore = itemy.Length;
        CelkemText.text = initialScore.ToString();
    }

    void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameObject[] itemy = GameObject.FindGameObjectsWithTag("Item");
        int score = initialScore - itemy.Length;
        ScoreText.text = score.ToString();
            if (itemy.Length == 0) {
                postup.SetActive(true);
                Time.timeScale = 0;
            }
    }
}
