using UnityEngine;

public class CarBot3Script : MonoBehaviour
{
    public float raycastLength = 10.0f;
    public float carSpeed = 120.0f;
    public float rotateSpeed = 5.0f;
    public GameObject beak;
    public Vector3 normalDirection;
    public Vector3 carDirection;
    public Vector3 rotationAngle;
    public bool turbo;
    Rigidbody botRb;
    void Start()
    {
        botRb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (turbo)
        {
            MoveCarFast();
        }
        else
        {
            MoveCar();
        }
            
    }
    void FixedUpdate()
    {
        RaycastHit hit1;
        if (Physics.Raycast(beak.transform.position, transform.right, out hit1, raycastLength))
        {
            if (hit1.collider.gameObject.CompareTag("RoadBorder"))
            {
                normalDirection = hit1.normal;
                float wallSide = Mathf.Sign(Vector3.Dot(normalDirection, transform.forward));
                transform.Rotate(transform.up, -wallSide * rotateSpeed);
                Vector3 refl = Vector3.Reflect(transform.right, normalDirection);

                Debug.DrawRay(hit1.point, normalDirection, Color.green, 2, false);
                Debug.DrawRay(beak.transform.position, transform.forward, Color.red, 2, false);
                Debug.DrawRay(beak.transform.position, transform.right, Color.yellow, 2, false);
                Debug.DrawRay(hit1.point, refl, Color.black, 2, false);
            }
        }

    }

    void MoveCarFast()
    {
        botRb.AddForce(Vector3.down * carSpeed * 0.5f);
        botRb.AddForce(transform.right * carSpeed * 1.5f);
    }

    void MoveCar()
    {
        botRb.AddForce(transform.right * carSpeed);
    }
}
