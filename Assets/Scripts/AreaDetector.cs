using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaDetector : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
            case "FIN 1":
                MyEvents.InvokeSomeEvent(1);
                break;
            case "FIN 2":
                MyEvents.InvokeSomeEvent(2);
                break;
            case "FIN 3":
                MyEvents.InvokeSomeEvent(3);
                break;
            case "death": 
                break;
            default:
                break;
        }
    }
}
