using Bang.Lib.ObjectPooling;
using System.Collections.Generic;
using UnityEngine;

public class ResetInPool : ReturnToMyPool
{
    [SerializeField] List<IResetComponent> ListComponentReset = new();
    public override void OnDisable()
    {
        base.OnDisable();
        if(ListComponentReset.Count >0)
        {
            foreach(IResetComponent component in ListComponentReset)
            {
                component.ResetObject();
            }
            return;
        }
        
        foreach(Transform child in transform)
        {
            if(child.gameObject.TryGetComponent<IResetComponent>(out var resetobject))
            {
                resetobject.ResetObject();
                ListComponentReset.Add(resetobject);
            }
        }
    }
}

internal interface IResetComponent
{
    void ResetObject();
}