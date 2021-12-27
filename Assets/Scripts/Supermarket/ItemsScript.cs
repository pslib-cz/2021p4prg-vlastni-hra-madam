using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemsScript : MonoBehaviour
{
    public int PocetChybProhra;
    public GameObject postup;
    public GameObject prohra;
    public Text ChybyText;
    public Text CelkemChybText;

    private int _chyby;

    void Start()
    {
        CelkemChybText.text = PocetChybProhra.ToString();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Jidlo"))
        {
            _chyby++;
            ChybyText.text = _chyby.ToString();
            collider.gameObject.SetActive(false);
            if (_chyby == PocetChybProhra) {
                prohra.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                GameObject[] pickups = GameObject.FindGameObjectsWithTag("Jidlo");
                GameObject[] spatneVeci = GameObject.FindGameObjectsWithTag("SpatnaVec");
                if(pickups.Length % 3 == 0 && spatneVeci.Length != 0) spatneVeci[0].GetComponent<Rigidbody2D>().WakeUp();
                if(pickups.Length != 0) pickups[0].GetComponent<Rigidbody2D>().WakeUp();
                else {
                    postup.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
        if (collider.gameObject.CompareTag("SpatnaVec"))
        {
                collider.gameObject.SetActive(false);
        }
    }
}
