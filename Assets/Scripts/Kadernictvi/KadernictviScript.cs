using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KadernictviScript : MonoBehaviour
{
    public float maxRunSpeed = 5;
    public float jumpSpeed = 5;
    public Text ScoreText;
    public GameObject postup;
    public GameObject prohra;

    private Rigidbody2D _rb;
    private Collider2D _col;
    private SpriteRenderer _sr;
    private Animator _anim;
    private bool _onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _onGround = _col.IsTouchingLayers();
        //float move = Input.GetAxis("Horizontal");
        //if (move !=0) _facingRight = (move < 0);
        //_sr.flipX = _facingRight;
        _anim.SetFloat("IsMoving", Mathf.Abs(maxRunSpeed));
        _anim.SetBool("IsJumping", !_onGround);
        //_rb.velocity = new Vector2(move * maxRunSpeed, _rb.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _onGround || Input.GetKeyDown(KeyCode.UpArrow) && _onGround)
        {
            _rb.AddForce(new Vector2(0,jumpSpeed), ForceMode2D.Impulse);
        }
        _rb.velocity = new Vector2(maxRunSpeed, _rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Item"))
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            prohra.SetActive(true);
            Time.timeScale = 0;
        }
        if (collider.gameObject.CompareTag("Zohan"))
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            postup.SetActive(true);
            Time.timeScale = 0;
        }
    }
}