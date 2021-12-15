using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UvodScript : MonoBehaviour
{
    public float maxRunSpeed = 5;
    public float jumpSpeed = 5;
    public Text ScoreText;

    private Rigidbody2D _rb;
    private Collider2D _col;
    private SpriteRenderer _sr;
    private Animator _anim;
    private bool _facingRight = false;
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
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
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Start"))
        {
            SceneManager.LoadScene("Moonbucks");
        }
    }
}