using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    [SerializeField]
    public UnityAction<Vector2> MoveEvent;
    [SerializeField]
    public UnityAction Jump;

    public void OnMove()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 InputVector = new Vector2(x, y);
        MoveEvent?.Invoke(InputVector);
    }
    private void Update()
    {
        OnMove();
    }

}
