using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    /*public float power = 10f;
    public float stompSpeed = 30f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;

    bool isStill = true;

    Vector3 dragStartPos;
    Touch touch;

    private void FixedUpdate()
    {
        

        if (rb.velocity == new Vector2(0, 0))
        {
            isStill = true;
        }

        else
        {
            isStill = false;
        }

        if(Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && !isStill)
            {
            
                rb.velocity = Vector2.down * stompSpeed;
            }

            if(touch.phase == TouchPhase.Began )//&& isStill)
            {
                DragStart();
            }

            if(touch.phase == TouchPhase.Moved )//&& isStill)
            {
                Dragging();
            }

            if(touch.phase == TouchPhase.Ended )//&& isStill)
            {
                DragRelease();
            }
        }
    }

    void DragStart()
    {
        dragStartPos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartPos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartPos);
    }

    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
    }

    void DragRelease()
    {
        lr.positionCount = 0;

        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartPos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
    }*/




























    public float power = 10f;
    public float stompSpeed = 30f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public float MinPower;
    public float MaxPower;
    public float dragForce;

    TragectoryLine tl;
    private Animator anim;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    bool isStill = true;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TragectoryLine>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.drag = dragForce;


        anim.SetBool("Still", isStill);
        
        
        if(Input.GetMouseButtonUp(0))
        {
            tl.EndLine();
        }

        if (rb.velocity == new Vector2(0, 0))
        {
            isStill = true;
        }

        else
        {
            isStill = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 5;
            tl.RenderLine(startPoint, currentPoint);
            
        }

        if(Input.GetMouseButtonUp(0))
        {
            tl.EndLine();
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            //force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            force = CalculatePowerVectorV2(startPoint, endPoint);
            rb.AddForce(force * power, ForceMode2D.Impulse);

            anim.SetTrigger("Jump");
            
        }

        if(Input.GetMouseButtonUp(0) && !isStill)
        {
            tl.lr.positionCount = 0;
        }

        if(Input.GetMouseButtonDown(0) && isStill == false)
        {
            
            // Gets rid of all previous velocity for a crunchy stomp.
            rb.velocity = Vector2.down * stompSpeed;
            //rb.AddForce(Vector2.down * stompSpeed, ForceMode2D.Impulse);
        }

        rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, dragForce * Time.deltaTime);

        StartCoroutine(IdleAnimation());
        
    }

    private Vector2 CalculatePowerVectorV2(Vector2 beginPoint, Vector2 endPoint)
    {
        //Vector2 difference = beginPoint-endPoint;
        Vector2 difference = new Vector2(Mathf.Clamp(beginPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(beginPoint.y - endPoint.y, minPower.y, maxPower.y));
        float vectorPower = difference.magnitude;
        vectorPower = Mathf.Clamp(vectorPower, MinPower, MaxPower);

        return difference.normalized * vectorPower;
    }

    private void FixedUpdate()
    {
        
        //float playerX = gameObject.transform.position.x;

        if((int)rb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if((int)rb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        /*else 
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }*/
    }

    private IEnumerator IdleAnimation()
    {
        yield return new WaitForSeconds(0.7f);
        if(isStill)
        {
            anim.SetTrigger("Idle");
        }
    }


}
