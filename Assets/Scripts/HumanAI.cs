using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HumanAI : MonoBehaviour
{
    public Transform food;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Transform enemyGFX;
    
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        InvokeRepeating("UpdatePath", 0f,.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, food.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        Vector2 velocity = rb.velocity;

        velocity.x = force.x;
        rb.velocity = velocity;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        
        if (velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-0.75f, 0.75f, 0.75f);
        }
        
        else if (velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
    }
    
}
