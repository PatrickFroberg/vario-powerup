using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] LayerMask _groundLayer;

    BoxCollider2D _boxCollider;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GetComponent<PlayerStats>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump");

        transform.Translate(direction * _playerStats.RunSpeed * Time.deltaTime, 0, 0);

        if (direction < 0)
            _spriteRenderer.flipX = true;

        if (direction > 0)
            _spriteRenderer.flipX = false;

        if (jump && GroundCheck())
            _rigidbody.AddForce(Vector3.up * _playerStats.JumpPower);


    }

    bool GroundCheck() 
    { 
        if (_playerStats.IsWitch == true)
            return true;

        return Physics2D.CapsuleCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, 0f, Vector2.down, 0.5f, _groundLayer); 
    }
}
