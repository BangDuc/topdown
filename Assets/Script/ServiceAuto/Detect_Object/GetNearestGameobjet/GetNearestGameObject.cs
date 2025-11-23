using System.Collections.Generic;
using UnityEngine;

public class GetNearestGameObjectService : MonoBehaviour
{
    [SerializeField]GameObject self;
    [SerializeField] GameObject nearest;
    [SerializeField] IServiceDetectGameObject detectGameObject;

    public GameObject GetNearest(List<GameObject> list)
    {
        float minSqrDistance = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject go in list)
        {
            Vector3 directionToTarget = go.transform.position - self.transform.position;
            float dSqrToTarget=directionToTarget.sqrMagnitude;
            if(dSqrToTarget < minSqrDistance)
            {
                minSqrDistance = dSqrToTarget;
                closest = go;
            }

        }
        return nearest=closest;
    }
    private void Start()
    {
        detectGameObject= GetComponent<IServiceDetectGameObject>();
        self=Player_Manager.Instance.Player;
    }
    private void Update()
    {
        GetNearest(detectGameObject.Get());
    }
}
