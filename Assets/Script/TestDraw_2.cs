using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawer : MonoBehaviour
{
    public int segments = 50; // Số đoạn thẳng để tạo nên hình tròn (càng cao càng mượt)
    public float radius = 5f;
    LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments; // Số điểm = số đoạn
        line.useWorldSpace = false; // Vẽ tương đối theo cha
        line.loop = true; // Nối điểm đầu cuối
        CreateCircle();
    }

    void CreateCircle()
    {
        float angle = 20f; // Góc giữa các điểm

        for (int i = 0; i < segments; i++)
        {
            // Công thức lượng giác tính tọa độ điểm trên đường tròn
            // x = r * cos(a), y = r * sin(a)
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }
}