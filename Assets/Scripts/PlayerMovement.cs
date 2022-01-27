using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody rb;
    private float horiz;
    private float vert;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(horiz, 0, vert) * Time.deltaTime * speed * 100;
        rb.velocity = move;
    }
}
