using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 2.5f;
    //public SpriteRenderer _renderer;
    private readonly float size = 75f;
    

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * (-speed) * Time.deltaTime);

        transform.position += (-speed) * Time.deltaTime * Vector3.right;


        if (transform.position.x <= -size)
        {
            transform.position = new Vector3(size*2, 0, 0);

            Debug.Log("Reset");
        }
    }

    
}
