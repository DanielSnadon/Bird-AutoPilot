using UnityEngine;

public class CarBot2Script : MonoBehaviour
{
    public float forcePower;
    public float rotationSpeed;
    public Vector3 rotationVector;
    private Rigidbody botRb;
    void Start()
    {
        botRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

    public void CheckerSignal(Vector3 checker)
    {
        rotationVector.z = checker.z - transform.position.z;
        transform.Rotate(transform.up, rotationVector.z * rotationSpeed);
        //botRb.AddForce(rotationVector * rotationSpeed);
    }
    void MoveCar()
    {
        botRb.AddForce(transform.right * forcePower);
    }
}
