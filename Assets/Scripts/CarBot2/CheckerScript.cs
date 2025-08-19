using System;
using UnityEngine;

public class CheckerScript : MonoBehaviour
{
    CarBot2Script car;
    private Vector3 touchPos;
    public void Start()
    {
        car = GameObject.Find("CarBot2").GetComponent<CarBot2Script>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadBorder"))
        {
            car.CheckerSignal(transform.position);
            touchPos = transform.position;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RoadBorder"))
        {
            car.CheckerSignal(touchPos);
        }
    }
}
