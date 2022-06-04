using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.InputSystem;

namespace ExydeToolbox{
    public class FastSceneReload : MonoBehaviour{

        enum InputMode {
            Legacy, New
        }

        [SerializeField] InputMode _inputMode = InputMode.New;

        [SerializeField] KeyCode reloadKey = KeyCode.R;

        void Update(){

            // if ( _inputMode == InputMode.New ){
            //     if (Keyboard.current.rKey.wasPressedThisFrame) Reload();
            // }

            if ( _inputMode == InputMode.Legacy ){
                if (Input.GetKeyDown (reloadKey)) Reload();
            }
        }

        void Reload(){
            SceneManager.LoadScene ( SceneManager.GetActiveScene().buildIndex);
        }
    }
}
    
