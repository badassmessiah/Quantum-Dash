using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Mathematics;

public class Dash : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector3 target;
    [SerializeField] private float maxDashCount = 3f;
    private float dashRemaining;

    void Start()
    {
        target = transform.position;
        ResetDashCount();
    }

    void Update()
    {   //get mouse clict and chech if dashes are remaining
        if (Input.GetMouseButtonDown(0) && dashRemaining > 0)
        {   //chech if mouse is over UI
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                //Move to mouse position
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.x, speed), Mathf.Lerp(transform.position.y, target.y, speed),0); //Vector3.Lerp(transform.position, target, speed);
                dashRemaining--;

            }
            
        }
   
    }

    public void ResetDashCount()
    {
        dashRemaining = maxDashCount;
    }

   
}
