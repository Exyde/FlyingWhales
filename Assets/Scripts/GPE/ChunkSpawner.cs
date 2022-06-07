using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _fishPrefabs;
    [SerializeField] List<GameObject> _garbagePrefabs;

    [SerializeField][Range (0, 100)] float _garbagePercentagePerChunk;
    [SerializeField] int _numberOfEntityPerChunk;
    [SerializeField] int _sphereSpawnRadius;

    [Header ("Debug")]
    [SerializeField] bool _debug;
    [SerializeField] Color _debugColor;
    [SerializeField] bool _clearTransformOnSpawn;

    [SerializeField] GameObject Player;


    TimerEvent _timerEvent;

    int JaugePollution;

    
    private void Awake()
    {
        Player = GameObject.Find("PF_Player");
            
    }
    private enum EntityType{
        Garbagae, Fish
    }


    public void SpawnNewChunk(){

        JaugePollution = Player.GetComponent<JaugeSystem>()._jaugeData.JaugePollution;
        float tempPercentage = Random.Range(Mathf.Sqrt(4.5f * JaugePollution), 20 + Mathf.Sqrt(6.3f * JaugePollution));
        _garbagePercentagePerChunk = Mathf.Clamp(tempPercentage, 0, 100);

        //Debug.Log("A popé avec un pourcentage de "+_garbagePercentagePerChunk);

        if (_clearTransformOnSpawn) ClearTransform();
        // Debug.Log("Spawning Chunks");
        for (int i = 0; i < _numberOfEntityPerChunk; i++){
        // Debug.Log("Spawning Chunk : " +  i);
            GameObject go = i < _garbagePercentagePerChunk ? InstantiateEntity(EntityType.Garbagae) : InstantiateEntity(EntityType.Fish);
            go.transform.parent = this.transform;
        }
    }

    GameObject InstantiateEntity(EntityType type){

        GameObject entity;
        if (type == EntityType.Fish) entity = _fishPrefabs[Random.Range(0, _fishPrefabs.Count)];
        else if (type == EntityType.Garbagae) entity = _garbagePrefabs[Random.Range(0, _garbagePrefabs.Count)];
        else return null;
        Vector3 pos = Random.insideUnitSphere * _sphereSpawnRadius;
        return Instantiate(entity, transform.position + pos, Quaternion.identity);
    }

    public void ClearTransform(){
        for (int i = 0; i < transform.childCount; i++){
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    #region Debug

    private void OnDrawGizmos()
    {
        if (!_debug) return;

        Gizmos.color = _debugColor;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _sphereSpawnRadius);
    }
    
    #endregion


}
