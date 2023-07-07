using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;
    bool isPlayerInRage;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
       if (other.transform == player)
        {
            isPlayerInRage = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerInRage = false;
        }
    }
    private void Update()
    {
        if (isPlayerInRage)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.magenta,Time.deltaTime);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray,out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CathPlayer();
                }
            }

        }      
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, player.position + Vector3.up);
    }
}
