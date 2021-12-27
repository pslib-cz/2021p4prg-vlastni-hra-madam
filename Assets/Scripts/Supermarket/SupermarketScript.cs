using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SupermarketScript : MonoBehaviour
{
    public float maxRunSpeed = 10;
    public GameObject postup;
    public GameObject prohra;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _anim;
    private bool _facingRight = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move !=0) _facingRight = (move < 0);
        _sr.flipX = _facingRight;
        _anim.SetFloat("IsMoving", Mathf.Abs(move));
        _rb.velocity = new Vector2(move * maxRunSpeed, _rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject[] pickups = GameObject.FindGameObjectsWithTag("Jidlo");
            pickups[5].GetComponent<Rigidbody2D>().WakeUp();
            GameObject.FindWithTag("Bublina").SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Jidlo"))
        {
            collider.gameObject.SetActive(false);
            GameObject[] pickups = GameObject.FindGameObjectsWithTag("Jidlo");
            if (pickups.Length == 0) {
                postup.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pickups[0].GetComponent<Rigidbody2D>().WakeUp();
                GameObject[] spatneVeci = GameObject.FindGameObjectsWithTag("SpatnaVec");
                if(pickups.Length % 3 == 0 && spatneVeci.Length != 0) spatneVeci[0].GetComponent<Rigidbody2D>().WakeUp();
            }
        }
        if (collider.gameObject.CompareTag("SpatnaVec"))
        {
                collider.gameObject.SetActive(false);
                prohra.SetActive(true);
                Time.timeScale = 0;
        }
    }
}
