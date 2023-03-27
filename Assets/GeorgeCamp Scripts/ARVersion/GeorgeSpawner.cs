using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeorgeSpawner : MonoBehaviour
{
    [SerializeField]private Transform George;
    [SerializeField]private List<Tree> treeList;
    [SerializeField]private int spawnRadius;
    [SerializeField]private GameObject playground;
    private static bool TheOneGeorge = false;
    void Awake()
    {
        if (TheOneGeorge)
            return;
        spawnGeorge();
        spawnTree();
        TheOneGeorge = true;
    }

    void spawnGeorge()
    {
        Instantiate(George, transform.position, transform.rotation);
    }
    void spawnTree()
    {
        var size = Vector3.Scale(playground.GetComponent<Renderer>().bounds.size, playground.transform.localScale);
        foreach(Tree tree in treeList)
        {
            Instantiate(tree, transform.position + new Vector3(Random.Range(-size.x, size.x),1, Random.Range(-size.z, size.z)), transform.rotation);
        }
    }
}
