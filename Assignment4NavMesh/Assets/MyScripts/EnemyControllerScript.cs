using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class EnemyControllerScript : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;

    //Uses AI to chase player.

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());

        if (target == null)
        {
            Debug.LogWarning("No target found.");
        }
    }



    // Update is called once per frame
    void Update()
    {
       
    }


    //Less resource intesive.. updates every quarter of a second rather than per frame..
    IEnumerator UpdatePath()
    {
        float refreshRate = .25f; //Refresh rate

        while(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }

        
    }

}

