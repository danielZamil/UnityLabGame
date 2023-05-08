using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartLogic : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource balloonPopSfx;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float deadZone = 11;
    [SerializeField] int missPenalty = -250;

    // Start is called before the first frame update
    void Start()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();

        if (balloonPopSfx == null)
            balloonPopSfx = GetComponent<AudioSource>();

        rigidBody.velocity = Vector2.right * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > deadZone)
        {
            PersistentData.Instance.AddScore(missPenalty);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Balloon")
        {
            PersistentData.Instance.AddScore(BalloonManager.balloonPoints);
            AudioSource.PlayClipAtPoint(balloonPopSfx.clip, transform.position);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}
