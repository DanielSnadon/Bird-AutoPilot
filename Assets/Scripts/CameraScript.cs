using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public enum CameraModes
    {
        FreeFly,
        SpectateEntity
    }
    public CameraModes cameraMode = CameraModes.FreeFly;
    public bool lookAtEntity;
    public GameObject cameraObj;

    public GameObject Entity;
    public float spectatingOffsetX;
    public float spectatingOffsetY;
    public float spectatingOffsetZ;

    public float cameraSpeed;
    public float cameraRotatingSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (cameraMode)
        {
            case (CameraModes.FreeFly):
                MoveCamera();
                break;
            case (CameraModes.SpectateEntity):
                TeleportToEntity();
                break;
        }
        if (lookAtEntity)
        {
            transform.LookAt(Entity.transform);
        }
    }
    void TeleportToEntity()
    {
        transform.position = Entity.transform.position + Vector3.up * spectatingOffsetY + Vector3.forward * spectatingOffsetX + Vector3.right * spectatingOffsetZ;
    }
    void MoveCamera()
    {
        transform.position += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * cameraSpeed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * cameraSpeed;
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(transform.up * Time.deltaTime * cameraSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-transform.up * Time.deltaTime * cameraSpeed);
        }
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * cameraRotatingSpeed);
        cameraObj.transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * cameraRotatingSpeed);
    }
}
