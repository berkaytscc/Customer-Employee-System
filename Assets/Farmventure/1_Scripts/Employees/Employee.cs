using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Employee : MonoBehaviour
{
    [HideInInspector] public Transform ServedCustomer;

    [SerializeField] private Transform _customerWaitPosition;
    [SerializeField] private MeshRenderer _customerSpotIndicator;
    [SerializeField] private GameObject _progressBarGO;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _progressBarBackground;

    private bool _servingACustomer;
    private float _progressBarFillSpeed;

    // Update is called once per frame
    void Update()
    {
        if(_servingACustomer && ServedCustomer != null)     // while serving a customer
        {
            //TODO: Make customer travel to the wait position

            if(_progressBar.fillAmount < 1f)
            {
                _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, 1f, Time.deltaTime * _progressBarFillSpeed);
            }
        }
    }

    public void PrepareOrder()  // this is calledd by: OrderAccepted
    {
        if(!_servingACustomer && ServedCustomer != null)    // employee is not in the serving process and has an assigned customer
        {
            StartCoroutine(OrderPrep());
        }
    }

    IEnumerator OrderPrep()
    {
        CustomerManager.ActiveCustomers.RemoveAt(0);   // employee's assigned customer

        _progressBarFillSpeed = 1f / Settings.EmployeeSettings.OrderPrepTime;
        _progressBarGO.SetActive(true);

        _servingACustomer = true;

        yield return new WaitForSeconds(Settings.EmployeeSettings.OrderPrepTime);

        if(ServedCustomer != null)  // TODO: debug here
        {
            ServedCustomer.gameObject.SetActive(false);
        }

        ServedCustomer = null;

        _servingACustomer = false;

        _progressBar.fillAmount = 0f;   // reset the progress bar;
        _progressBarGO.SetActive(false);
    }
}
