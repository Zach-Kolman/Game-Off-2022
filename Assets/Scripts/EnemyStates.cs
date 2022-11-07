using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour
{
    [SerializeField]
    public enum EnemyState { Idle, Walking, Turning, SawYou }
    public EnemyState currentState;

    public Transform[] waypoints;

    public Transform currentWaypoint;

    public int waypointInList;

    private NavMeshAgent agent;

    public bool returning = false;

    private Animator animator;

    public Camera fieldOfView;

    [HideInInspector]
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        agent = gameObject.GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", agent.speed);

        CheckIfReturning();

        currentWaypoint = waypoints[waypointInList];
        Vector3 offset = transform.position - currentWaypoint.position;

        switch (currentState)
        {
            case EnemyState.Idle:
                agent.speed = Mathf.MoveTowards(agent.speed, 0, Time.deltaTime * 4);
                StartCoroutine(WaitAtWaypoint());

                break;

            case EnemyState.Walking:
                agent.destination = currentWaypoint.position;
                agent.speed = Mathf.Lerp(agent.speed, 2, Time.deltaTime * 4);

                if (offset.magnitude > 0.65f)
                {
                    return;
                }
                else
                {
                    currentState = EnemyState.Idle;
                }
                break;

            case EnemyState.Turning:

                break;

            case EnemyState.SawYou:

                break;
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        yield return new WaitForSeconds(currentWaypoint.GetComponent<TimeToWait>().timeToWait);

        if (!returning)
        {
            waypointInList++;
        }
        else if (returning)
        {
            waypointInList--;
        }

        currentState = EnemyState.Walking;
        StopAllCoroutines();
    }

    void CheckIfReturning()
    {
        if (waypointInList == waypoints.Length - 1)
        {
            returning = true;
        }
        else if (waypointInList == 0)
        {
            returning = false;
        }
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {

    }

    
}

