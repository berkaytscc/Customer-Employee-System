using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    [SerializeField] private int _counterLayer;
    [SerializeField] private int _customerLayer;
    [SerializeField] private string _entranceTag;

    private bool _waitingInLine;
    private GameObject _customerInFront;

    public Transform TargetWaypoint;
    public bool EnterenceReached;

    private void OnEnable()
    {
        _waitingInLine = false;
        _customerInFront = null;
        EnterenceReached = false;
    }

    private void Update()
    {
        //TODO: improvement needed
        if (TargetWaypoint != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetWaypoint.position, Settings.CustomerSettings.MovementSpeed * Time.deltaTime);
        }

        if (_customerInFront == null)
        {
            _waitingInLine = false; // if no customer waiting in front, stop waiting
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _entranceTag)    // when customer reaches the first waypoint
        {
            EnterenceReached = true;

            TargetWaypoint = CustomerManager.Instance.GetRandomSpot().Waypoint;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
