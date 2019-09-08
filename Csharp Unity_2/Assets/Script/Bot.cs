using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]

public class Bot : Unit
{

    private NavMeshAgent _agent;
    private ThirdPersonCharacter _controller;
    private Transform _playerPos;
    private Vector3 _startPos;
    private Transform _target;

    private int _aciveDistance = 10;
    private int _stopDistance = 1;

    private float _activeAngle = 30;

    private bool _isTaget;
    private bool _isDeath;

    private List<Vector3> _wayPoint = new List<Vector3>();
    private int _wayCount;
    private GameObject wayPoint;

    private float _timeWait = 2f;
    private float _timeOut;

    private bool angry;
    private bool patrol;
    private bool Shooting;


    private float _maxAngle = 30;
    private float _maxRadius = 20;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _maxRadius);

        Vector3 fovLineLeft = Quaternion.AngleAxis(-_maxAngle, transform.up) * transform.forward * _maxRadius;

        Vector3 fovLineRight = Quaternion.AngleAxis(_maxAngle, transform.up) * transform.forward * _maxRadius;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, fovLineLeft);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, fovLineRight);
    }


    protected override void Awake()
    {
        base.Awake();
        Helth = 100;
        patrol = true;

        _agent = GetComponent<NavMeshAgent>();
        _controller = GetComponent<ThirdPersonCharacter>();
        _agent.updatePosition = true;
        _agent.updateRotation = true;

        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        _startPos = Position;

        _agent.SetDestination(_playerPos.position);


        wayPoint = GameObject.FindGameObjectWithTag("WayPoint");

        foreach (Transform T in wayPoint.transform)
        {
            _wayPoint.Add(T.position);

        }
    }

    private void ChangeWayPoint()
    {
        if(_wayCount< _wayPoint.Count - 1)
        {
            _wayCount++;

        }
        else
        {
            _wayCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            patrol = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            patrol = true;
        }
    }

    void Update()
    {
        if (_agent)
        {

            if (_agent.remainingDistance > _agent.stoppingDistance)
            {
                _controller.Move(_agent.desiredVelocity, false, false);
                Anim.SetBool("move", true);
            }
            else
            {
                _controller.Move(Vector3.zero, false, false);
                Anim.SetBool("move", false);

            }
            if (patrol)
            {
                if (_wayPoint.Count >= 2 && !_isTaget)
                {
                    _agent.stoppingDistance = _stopDistance;
                    _agent.SetDestination(_wayPoint[_wayCount]);
                    if (!_agent.hasPath)
                    {
                        _timeOut += 0.1f;

                        if (_timeOut > _timeWait)
                        {
                            _timeOut = 0;
                            ChangeWayPoint();
                        }
                    }
                }
                else if (_wayPoint.Count == 0)
                {
                    _agent.stoppingDistance = 5f;
                    _agent.SetDestination(_playerPos.position);
                }
            }
            else
            {
                _agent.stoppingDistance = 5f;
                _agent.SetDestination(_playerPos.position);
                Vector3 RayPos = new Vector3(Position.x, Position.y + 1, Position.z);
                Ray ray = new Ray(RayPos, transform.forward);
                RaycastHit hit;
                Debug.DrawRay(RayPos, transform.forward, Color.grey);
                if (Physics.Raycast(ray, out hit, _maxRadius))
                {
                    if (hit.collider.tag == "Player")
                    {
                        Debug.Log("player");


                    }
                }
            }

        }
    }
}
