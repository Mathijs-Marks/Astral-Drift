using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//<Summary>
//This script is used to update the mesh of the terrain outside of the playmode, thus allowing for easier customisation
//<Summary>

public class UpdatableData : ScriptableObject
{
    public event System.Action OnValuesUpdated;
    public bool autoUpdate;

#if UNITY_EDITOR

    protected virtual void OnValidate()
    {
        if (autoUpdate)
        {
            UnityEditor.EditorApplication.update += NotifyOfUpdatedValues;
        }
    }
    public void NotifyOfUpdatedValues()
    {
        UnityEditor.EditorApplication.update -= NotifyOfUpdatedValues;
        if(OnValuesUpdated != null)
        {
            OnValuesUpdated();
        }
    }
#endif
}
