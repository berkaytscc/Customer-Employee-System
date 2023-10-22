using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager : MonoBehaviour
{
    [SerializeField] private Transform _employeesParent;

    public static List<Employee> ActiveEmployees = new List<Employee>();
    public static List<GameObject> AllEmployees = new List<GameObject>();
}
