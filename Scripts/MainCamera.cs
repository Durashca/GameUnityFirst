using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform trackingObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(trackingObject.position.x, trackingObject.position.y, trackingObject.position.z);
    }
}
