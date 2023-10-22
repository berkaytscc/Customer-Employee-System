using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private Transform _customerParent;

    private string _counterTag = "Counter";

    public List<CustomerWaypoint> Waypoints = new List<CustomerWaypoint>();
    public static CustomerManager Instance { get; private set; }
    public static List<Transform> AllCustomers = new List<Transform>();
    public static List<GameObject> ActiveCustomers = new List<GameObject>();

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < _customerParent.childCount; i++)
        {
            AllCustomers.Add(_customerParent.GetChild(i));
        }
    }
    private void OnValidate()
    {
        GameObject counter = GameObject.FindWithTag(_counterTag);

        if (counter != null)
        {
            var customerSpots = counter.transform.Find("CustomerSpots");

            if (customerSpots != null)
            {
                Waypoints.Clear();

                foreach (Transform waypoint in customerSpots)
                {
                    CustomerWaypoint customerWaypoint = new CustomerWaypoint(waypoint);
                    Waypoints.Add(customerWaypoint);
                }
            }
            else
            {
                Debug.LogWarning("No 'CustomerSpots' found under the 'Counter' GameObject.");
            }
        }
        else
        {
            Debug.LogWarning("No GameObject with tag '" + _counterTag + "' found.");
        }
    }

    public bool CanSpawnNewCustomer()
    {
        return Waypoints.Any(x => x.IsAvailable);
    }

    /// <summary>
    /// Returns an available waypoint for customer.
    /// </summary>
    /// <returns></returns>
    public CustomerWaypoint GetRandomSpot()
    {
        if(CanSpawnNewCustomer())
        {
            var availableWaypoints = Waypoints.Where(x => x.IsAvailable).ToList();

            int randomIndex = Random.Range(0, availableWaypoints.Count());

            availableWaypoints[randomIndex].IsAvailable = false;    // waypoint is not available for other customers.

            return availableWaypoints[randomIndex];
        }

        return null;
    }
}
