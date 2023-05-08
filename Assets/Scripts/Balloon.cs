using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    [SerializeField] float moveSpeed;
    [SerializeField] float initialAngle;
    [SerializeField] float scaleSpeed = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        if (rigidBody == null)
            rigidBody = GetComponent<Rigidbody2D>();


        int difficulty = PersistentData.Instance.GetDifficulty();
        moveSpeed = Random.Range(3 + difficulty * 2, 7 + 3 + difficulty * 3);

        rigidBody.velocity = Vector3.up * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        if(transform.localScale.x <= 4)
            transform.localScale += new Vector3(1, 1, 0) * scaleSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (rigidBody.position.x > 8.3 || rigidBody.position.x < -8.3)
            rigidBody.velocity = new Vector3(-rigidBody.velocity.x, rigidBody.velocity.y, 0);
        if (rigidBody.position.y > 4.3 || rigidBody.position.y < -4.4)
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, -rigidBody.velocity.y, 0);
    }
}
