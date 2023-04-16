using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
	    if (collision.gameObject.CompareTag($"McGuffin") && collision.gameObject!=null)
	    {
		    var mcguffinComp = collision.GetComponent<McGuffin>();
		    
		    UIManager.instance.DisplayText(mcguffinComp.UIText);
	    }
    }
}
