using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripttokill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log("Exited collision with " + collision.gameObject.name);
    }

    //Hitting a collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
       // Debug.Log("Exited collision with " + collision.gameObject.name);
    }

    //Just stop hitting a collider 2D
    private void OnCollisionExit2D(Collision2D collision)
    {
      //  Debug.Log("Exited collision with " + collision.gameObject.name);
    }
}
