using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource fireSfx;

    [SerializeField] GameObject dart;

    [SerializeField] private Vector2 inputMovement;
    [SerializeField] float moveSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (fireSfx == null)
            fireSfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!BalloonManager.GameIsPaused)
        {
            inputMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Fire1"))
            {
                fireDart();
            }



            if (inputMovement.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (inputMovement.x < 0)
            {
                spriteRenderer.flipX = true;
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8, -3), Mathf.Clamp(transform.position.y, -4, 4), 0);

        }
    }

    private void FixedUpdate()
    {   

        rigidBody.velocity = new Vector3(inputMovement.x, inputMovement.y, 0).normalized * moveSpeed;
    }


    void fireDart()
    {
        AudioSource.PlayClipAtPoint(fireSfx.clip, transform.position);
        Instantiate(dart, transform.position, transform.rotation);
    }
}
