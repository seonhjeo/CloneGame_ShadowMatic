using UnityEngine;
using UnityEngine.EventSystems;


public partial class ObjectRotate // Properties and Methods that other classes can use
{}

public partial class ObjectRotate // Properties and Methods that only this classes use
{
    private const float RotateSpeed = 100f;

    public void OnDrag(PointerEventData eventData) => _OnDrag(eventData);
}

// Class Body
public partial class ObjectRotate : MonoBehaviour
{
}

public partial class ObjectRotate : IDragHandler
{
    private void _OnDrag(PointerEventData eventData)
    {
        float offset = Time.deltaTime * RotateSpeed;
        float x = 0, y, z = 0;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            y = eventData.delta.y;
            z = eventData.delta.x;
        }
        else
        {
            x = eventData.delta.x;
            y = eventData.delta.y;
        }

        transform.Rotate(Vector3.up, -x * offset, Space.World);
        transform.Rotate(Vector3.left, -y * offset, Space.World);
        transform.Rotate(Vector3.forward, -z * offset, Space.World);
    }
}
