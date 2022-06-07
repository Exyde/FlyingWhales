using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEditor : MonoBehaviour
{
    public List<GameObject> ListSpawn;

    public AnimationCurve _curve;


    public List<Transform> ListePositionChunk;

    int RandomN;

    [SerializeField] int NbSpawnDepart = 10;

    public bool _debug;
    public float _gizmosRadius;

    [SerializeField] GameObject PrefabSpawn;


    private void Start()
    {

        for (int i = 0; i != ListePositionChunk.Count; i++)
        {
            ListSpawn.Add(Instantiate(PrefabSpawn, ListePositionChunk[i].position, transform.rotation, transform));
        }

        for (int i = 0; i != NbSpawnDepart; i++)
        {
            RandomGeneration();
        }
        
        


    }

    public void RandomGeneration()
    {
        RandomN = Random.Range(0, ListSpawn.Count);

        ChunkSpawner CurentChawk = ListSpawn[RandomN].GetComponent<ChunkSpawner>();

        CurentChawk.ClearTransform();

        CurentChawk.SpawnNewChunk();


    }

    public void RandomDestruction()
    {
        RandomN = Random.Range(0, ListSpawn.Count);

        ListSpawn[RandomN].GetComponent<ChunkSpawner>().ClearTransform();


    }

    void OnDrawGizmos()
    {
        if (!_debug) return;

        Gizmos.color = Color.green;

        foreach (Transform t in ListePositionChunk)
        {
            Gizmos.DrawSphere(t.position, _gizmosRadius);
        }
    }


}
