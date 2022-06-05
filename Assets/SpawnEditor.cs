using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEditor : MonoBehaviour
{
    public List<GameObject> ListSpawn;

    public List<Vector3> ListePositionChunk;

    [SerializeField] GameObject PrefabSpawn;

    private void Start()
    {
        Debug.Log(ListePositionChunk.Count);

        for (int i = 0; i != ListePositionChunk.Count; i++)
        {
            ListSpawn.Add(Instantiate(PrefabSpawn, ListePositionChunk[i],transform.rotation, transform));
        }
        
    }
}
