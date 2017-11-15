using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    private float panBorderThickness = 10f;
    private float currentX = 0f;

    public float scrollSpeed = 2f;
    public float minY = 10f;
    public float maxY = 50f;
    public float sensitivityX = 15f;

    public CameraBounds camBounds;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("w")/* || Input.mousePosition.y >= Screen.height - panBorderThickness*/)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s")/* || Input.mousePosition.y <= panBorderThickness*/)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d")/* || Input.mousePosition.x >= Screen.width - panBorderThickness*/)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a")/* || Input.mousePosition.x <= panBorderThickness*/)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos = camBounds.GetAdjustedPos(pos);

        transform.position = pos;

        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        //transform.LookAt(transform.position + Vector3.up);
        transform.RotateAround(Camera.main.transform.position, Vector3.down, currentX);
    }
}