using Mono.Cecil.Cil;
using UnityEngine;

public class CarBot1Script : MonoBehaviour
{
    public GameObject ray1;
    public GameObject ray2;
    private RayScript ray1Script;
    private RayScript ray2Script;
    private Rigidbody botRb;
    public float forcePower;
    public float rotationSpeed;
    public int rayFirstActivated = 0;
    public int raysActivated = 0;
    void Start()
    {
        
        ray1Script = ray1.GetComponent<RayScript>();
        ray2Script = ray2.GetComponent<RayScript>();
        botRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRays();
        MoveCar();
        
        
    }
    void MoveCar()
    {
        botRb.AddForce(transform.right * forcePower);
        transform.Rotate(Vector3.up, -raysActivated * rotationSpeed * rayFirstActivated);
    }
    void CheckRays()
    {
        if (rayFirstActivated != 0 && !ray1Script.activated && !ray2Script.activated)
        {
            raysActivated = 0;
            rayFirstActivated = 0;
        }
        if (rayFirstActivated == 1 && !ray1Script.activated)
        {
            rayFirstActivated = 0;
        }
        if (rayFirstActivated == -1 && !ray2Script.activated)
        {
            rayFirstActivated = 0;
        }
        
        if (rayFirstActivated == 0)
        {
            if (ray1Script.activated)
            {
                rayFirstActivated = 1;
                raysActivated = 1;
            }
            else if (ray2Script.activated)
            {
                rayFirstActivated = -1;
                raysActivated = 1;
            }
        }
        else if (rayFirstActivated != 0 && raysActivated == 1)
        {
            if (rayFirstActivated == 1 && ray2Script.activated)
            {
                raysActivated = 2;
            }
            if (rayFirstActivated == -1 && ray1Script.activated)
            {
                raysActivated = 2;
            }
        }
    }
}
