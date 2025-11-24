using UnityEngine;

public class AutoDisableService : MonoBehaviour, IAutoDisable
{
    [SerializeField]
    private float _time_exist;
    [SerializeField]
    private float _current_time;
    public float time_exist { get=> _time_exist; set=> _time_exist=value; }
    public float current_time { get=> _current_time; set=> _current_time= value; }

    public void AutoDisable()
    {
        if(current_time< time_exist)
        {
            current_time += Time.deltaTime;
        }
       

        if (current_time >= time_exist)
        {
            current_time = 0;
            gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        AutoDisable();

    }
    public void resetTime()
    {
        current_time = 0;
    }
    public void SetTimeExist(float time_exist)
    {
        this.time_exist = time_exist;
    }
    private void OnEnable()
    {
        resetTime();
    }

}

public interface IAutoDisable
{
    void AutoDisable();
    float time_exist { get; set; }
    float current_time { get; set; }
    void SetTimeExist(float time_exist);


}