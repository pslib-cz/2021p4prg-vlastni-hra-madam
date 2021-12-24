using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorScript : MonoBehaviour
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
        /*if (collider.gameObject.CompareTag("Jidlo"))
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
        }*/
        if (collider.gameObject.CompareTag("Item"))
        {
                collider.gameObject.SetActive(false);
                GameObject[] itemy = GameObject.FindGameObjectsWithTag("Item");
                if(itemy.Length >= 4) {
                    itemy[0].GetComponent<Rigidbody2D>().WakeUp();
                    itemy[1].GetComponent<Rigidbody2D>().WakeUp();
                    itemy[2].GetComponent<Rigidbody2D>().WakeUp();
                    itemy[3].GetComponent<Rigidbody2D>().WakeUp();
                } 
                else if (itemy.Length != 0) itemy[0].GetComponent<Rigidbody2D>().WakeUp();
                else SceneManager.LoadScene("Supermarket");
                //GameObject[] spatneVeci = GameObject.FindGameObjectsWithTag("SpatnaVec");
                //if(spatneVeci.Length != 0) spatneVeci[0].GetComponent<Rigidbody2D>().WakeUp();
        }
    }
}
