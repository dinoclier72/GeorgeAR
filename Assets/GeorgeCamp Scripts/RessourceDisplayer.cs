using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class RessourceDisplayer : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/ResourceDisplayer")]
    public static void AddResourceDisplayer()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/PlayerResourceTracker"));
        obj.transform.SetParent(Selection.activeGameObject.transform,false);
    }
#endif
    public Resource resource;
    private void Awake()
    {
        resource.OnResourceUpdated += delegate (object sender, EventArgs e)
        {
            UpdateResourceDisplay();
        };
        UpdateResourceDisplay();
    }
    private void UpdateResourceDisplay()
    {
        transform.Find("ressourceNumber").GetComponent<TextMeshProUGUI>().text = "" + resource.GetAmount();
    }
}
