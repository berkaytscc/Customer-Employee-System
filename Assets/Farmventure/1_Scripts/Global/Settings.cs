using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private EmployeeSettings _employeeSettings;
    public static EmployeeSettings EmployeeSettings;

    [SerializeField] private CustomerSettings _customerSettings;
    public static CustomerSettings CustomerSettings;

    private void Awake()
    {
        EmployeeSettings = _employeeSettings;
        CustomerSettings = _customerSettings;
    }
}
