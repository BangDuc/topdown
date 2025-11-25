using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawer : MonoBehaviour
{
    public int segments = 50; 
    public float radius = 5f;
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments; 
        line.useWorldSpace = false; 
        line.loop = true; 
        CreateCircle();
    }

    void CreateCircle()
    {
        float angle = 20f; 

        for (int i = 0; i < segments; i++)
        {
            
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }
}