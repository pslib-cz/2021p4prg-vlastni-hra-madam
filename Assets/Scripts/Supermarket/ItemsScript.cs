using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemsScript : MonoBehaviour
{
    public Text ChybyText;
    public int PocetChybProhra;

    private Rigidbody2D _rb;
    private Collider2D _col;
    private SpriteRenderer _sr;

    private int _chyby;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Jidlo");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Jidlo"))
        {
            _chyby++;
            collider.gameObject.SetActive(false);
            //ChybyText.SetText("Chyb:"  + _chyby);
            if (_chyby == PocetChybProhra) {
                SceneManager.LoadScene("Supermarket");
            }
            else
            {
                GameObject[] pickups = GameObject.FindGameObjectsWithTag("Jidlo");
                GameObject[] spatneVeci = GameObject.FindGameObjectsWithTag("SpatnaVec");
                if(pickups.Length % 3 == 0 && spatneVeci.Length != 0) spatneVeci[0].GetComponent<Rigidbody2D>().WakeUp();
                if(pickups.Length != 0) pickups[0].GetComponent<Rigidbody2D>().WakeUp();
                else SceneManager.LoadScene("Park");
            }
        }
        if (collider.gameObject.CompareTag("SpatnaVec"))
        {
                collider.gameObject.SetActive(false);
                //GameObject[] spatneVeci = GameObject.FindGameObjectsWithTag("SpatnaVec");
                //if(spatneVeci.Length != 0) spatneVeci[0].GetComponent<Rigidbody2D>().WakeUp();
        }
    }
}
