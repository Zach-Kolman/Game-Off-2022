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

    public GameObject alertLight;

    public Camera fieldOfView;

    public AudioClip alertSound;

    public AudioClip lineSound;

    public AudioSource alertSource;

    private bool audioPlayed = false;

    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

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
                agent.speed = Mathf.Lerp(agent.speed, 1, Time.deltaTime * 4);

                if (offset.magnitude > 1f)
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

                if (audioPlayed) break;
                agent.speed = 0;

                alertLight.SetActive(true);

                alertSource.playOnAwake = false;

                alertSource.clip = alertSound;

                //AudioSource lineSource = gameObject.AddComponent<AudioSource>();

                //lineSource.clip = lineSound;

                //lineSource.playOnAwake = false;

                //lineSource.volume = 0.4f;

                //alertSource.pitch = Random.Range(0.65f, 1f);

                alertSource.volume = 0.4f;

                alertSource.Play();

                //lineSource.Play();

                StartCoroutine(TurnToPlayer());

                audioPlayed = true;
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
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(gameObject.transform.position), FootstepAudioVolume);
            }
        }
    }

    IEnumerator TurnToPlayer()
    {
        Vector3 playerDirection = player.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, playerDirection, 360 * Time.deltaTime, 1);

        transform.rotation = Quaternion.LookRotation(newDirection);

        animator.SetBool("SeenPlayer", true);

        yield return new WaitForSeconds(1.5f);
    }
}

