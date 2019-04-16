using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private Transform targetTransform, playerTransform;
    private float mouseX, mouseY;
    [SerializeField] private float verticalClampMin = -35, verticalClampMax = 60;

    [SerializeField] private Transform obstruction;
    [SerializeField] private float zoomSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        obstruction = targetTransform;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraControl();
        ViewObstructed();
    }
    void CameraControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * -rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, verticalClampMin, verticalClampMax);

        transform.LookAt(targetTransform);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetTransform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            targetTransform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            playerTransform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
    void ViewObstructed()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,targetTransform.position-transform.position,out hit, 4.5f))
        {
            if (hit.collider.gameObject.tag!="Player")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if (Vector3.Distance(obstruction.position,transform.position)>3f&&Vector3.Distance(transform.position,targetTransform.position)>=1.5f)

                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position,targetTransform.position)<4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }
}
