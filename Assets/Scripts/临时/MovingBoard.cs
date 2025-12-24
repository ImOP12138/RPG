using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoard : Board
{
    public Vector3 destination;
    public Vector3 origin;
    public bool isLerp = false;
    public float distance;
    
    private Vector3 currentTarget;
    private bool isMoving;
    private SpriteRenderer sr;
    private Collider2D coll;

    public float speed;
    public bool alwaysWorking;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        origin = transform.position;
        destination = transform.position + destination;
        if (alwaysWorking)
            SwitchOn();
    }

   

    protected override void SwitchOn()
    {
        base.SwitchOn();

        sr.enabled = false;
        coll.enabled = false;
        
        isMoving = true;
    }

    protected override void SwitchOff()
    {
        base.SwitchOff();

        sr.enabled = true;
        coll.enabled = true;
        
        isMoving = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(destination, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + destination);

        if (targetSwitch != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(targetSwitch.transform.position, 0.5f);
            Gizmos.DrawLine(transform.position, targetSwitch.transform.position);
        }
    }
}
