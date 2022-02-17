using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Transform[] waypoints;

    private int currWaypointIndex = 0;
    private float speed = 6f;
    private bool paused = false;

    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlatform();

        if(transform.position == waypoints[currWaypointIndex].position)
        {
            DetermineNextWaypoint();
        }
    }

    void MovePlatform()
    {
        float step = speed * Time.deltaTime;
        Vector3 newPos = Vector3.MoveTowards(transform.position, waypoints[currWaypointIndex].position, step);
        if (!paused)
        {
            rb.MovePosition(newPos);
        }

        if (cc)
        {
            cc.Move(rb.velocity * Time.deltaTime);
        }
    }

    void DetermineNextWaypoint()
    {
        StartCoroutine(StopPlatform());

        currWaypointIndex++;
        if (currWaypointIndex >= waypoints.Length)
        {
            currWaypointIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cc = other.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cc = null;
        }
    }

    IEnumerator StopPlatform()
    {
        paused = true;
        yield return new WaitForSeconds(1.0f);
        paused = false;
    }
}
