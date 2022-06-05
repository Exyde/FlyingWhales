using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] PlayerController _player;
    [SerializeField] Camera _cam;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    #region Public Methods
    public void ReloadGame()
    {

    }
    public void SetupGame()
    {

    }
    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion


    

}
