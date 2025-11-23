using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DetectBase : MonoBehaviour, IServiceDetectGameObject
{
    [SerializeField] Collider2D DetectZone;
    [SerializeField] List<GameObject> DetectZoneList =new List<GameObject>();
    [SerializeField] List<string> Tags;
    public List<GameObject> Get()
    {
        return DetectZoneList;
    }

    public bool isDetect()
    {
        if (DetectZoneList.Count > 0) return true;
        return false;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in Tags)
        {
            if (collision.tag == tag)
            {
                DetectZoneList.Add(collision.gameObject);
            }
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!DetectZoneList.Contains(collision.gameObject)) return;
        DetectZoneList.Remove(collision.gameObject);
    }


}
