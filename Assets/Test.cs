using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    public Vector2 myLocation;
    public Vector2 targetLocation;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        RotationTransformation();
    }

    public void RotationTransformation()
    {
        // �� GPS ��ǥ ����, Pokemon ������Ʈ�� GPS(x1, y1)�� ���
        float x1 = Mathf.Abs(myLocation.x - targetLocation.x) * 100000; // 0.0002 * 100000 = 2
        float y1 = Mathf.Abs(myLocation.y - targetLocation.y) * 100000; // 0.0011 * 100000 = 110

        angle *= Mathf.Deg2Rad;

        float x2 = (Mathf.Cos(angle) * x1) + (-Mathf.Sin(angle) * y1); // 
        float y2 = (Mathf.Sin(angle) * x1) + (Mathf.Cos(angle) * y1);

        Vector3 newTargetCoordinates = new Vector3(x2, 0, y2);
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.localScale = Vector3.one * 10;
        go.transform.position = newTargetCoordinates;

        Debug.Log($"Angle({angle}), Before({x1}, {y1}), After({x2}, {y2})\n");
    }
}
