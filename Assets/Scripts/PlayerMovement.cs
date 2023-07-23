using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{  
    public GameObject bulletPreFab;
    public Transform bulletSpawnPoint;

    public Rigidbody2D rBody;
    public Animator anim;

    public float bulletSpeed;
    public float moveSpeed;

    private Vector2 movementInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPreFab, bulletSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rbody = bullet.GetComponent<Rigidbody2D>();
            rbody.velocity = transform.up * bulletSpeed;
        }
    }

    private void FixedUpdate()
    {
        rBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}