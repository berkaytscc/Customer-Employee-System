using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _customer;
    [SerializeField] private Transform _customerSpawnPoint;
    [SerializeField] private Transform _spawnParent;
    [SerializeField] private Transform _enterence;

    private List<GameObject> _customerPool = new List<GameObject>();
    private GameObject _newCustomer;
    private int _poolCapacity;
    //private float _spawnCoolDown = 1f;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateCustomers();
    }

    private void InstantiateCustomers()
    {
        //TODO: We should set _poolCapacity based on employee limit
        _poolCapacity = Settings.CustomerSettings.MaxSpawn;

        for (int i = 0; i < _poolCapacity; i++)
        {
            GameObject newCustomer = Instantiate(_customer, _customerSpawnPoint.position, _customerSpawnPoint.rotation, _spawnParent);
            newCustomer.SetActive(false);
            _customerPool.Add(newCustomer);
        }
    }

    private void SpawnCustomer()
    {
        _newCustomer = GetOneCustomerFromPool();

        if (_newCustomer != null)
        {
            _newCustomer.transform.position = _customerSpawnPoint.position;
            _newCustomer.GetComponent<CustomerMovement>().TargetWaypoint = _enterence;
            _newCustomer.SetActive(true);
            CustomerManager.ActiveCustomers.Add(_newCustomer);

            _newCustomer = null;    // reset reference
        }
    }

    public void SpawnCustomerManually() // this will be called by spawn button
    {
        if (CustomerManager.ActiveCustomers.Count <= Settings.CustomerSettings.MaxSpawn)
        {
            SpawnCustomer();
        }
        else
        {
            Debug.Log("All waypoints are occupied");
        }
    }

    private GameObject GetOneCustomerFromPool()
    {
        foreach (var customer in _customerPool)
        {
            if (!customer.activeSelf)
            {
                return customer;
            }
        }

        return null;
    }
}
