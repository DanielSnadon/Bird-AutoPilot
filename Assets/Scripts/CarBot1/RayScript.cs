using Unity.VisualScripting;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public bool activated = false;

    public void Update()
    {
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadBorder"))
        {
            activated = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RoadBorder"))
        {
            activated = false;
        }
    }
}
