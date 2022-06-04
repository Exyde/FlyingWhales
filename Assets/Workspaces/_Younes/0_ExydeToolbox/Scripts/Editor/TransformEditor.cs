// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEditor;

// namespace ExydeToolbox{

//     [CustomEditor(typeof(Transform))]
//     [CanEditMultipleObjects]
//     public class TransformEditor : Editor
//     {
//         SerializedProperty _positionProp;
//         SerializedProperty _rotationProp;
//         SerializedProperty _scaleProp;

//         string refReshTexture = "d_Refresh";
//         int buttonWidth = 20;

//         void OnEnable(){
//             _positionProp = serializedObject.FindProperty("m_LocalPosition");
//             _rotationProp = serializedObject.FindProperty("m_LocalRotation");
//             _scaleProp = serializedObject.FindProperty("m_LocalScale");
//         }

//         public override void OnInspectorGUI(){
    
//             serializedObject.Update();

//             DrawPropertyRegion(buttonWidth);
//             DrawCopyRegion();

//             serializedObject.ApplyModifiedProperties();
//         }

//         void DrawPropertyRegion(int buttonWidth){
//             //Posiiton
//             EditorGUILayout.BeginVertical();
//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.PropertyField(_positionProp, new GUIContent("Position"));    

//             if (GUILayout.Button(EditorGUIUtility.FindTexture (refReshTexture), GUILayout.Width(buttonWidth)))
//                 _positionProp.vector3Value = Vector3.zero;
//             EditorGUILayout.EndHorizontal();

//             //Rotation
//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.PropertyField(_rotationProp, new GUIContent("Rotation"), true);    

//             if (GUILayout.Button(EditorGUIUtility.FindTexture (refReshTexture), GUILayout.Width(buttonWidth)))
//                 _rotationProp.vector4Value = new Vector4(0,0,0,0);
//             EditorGUILayout.EndHorizontal();

//             //Scale
//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.PropertyField(_scaleProp, new GUIContent("Scale"));    

//             if (GUILayout.Button(EditorGUIUtility.FindTexture (refReshTexture), GUILayout.Width(buttonWidth)))
//                 _scaleProp.vector3Value = Vector3.one;
//             EditorGUILayout.EndHorizontal();
//             EditorGUILayout.EndVertical();     
//         }

//         void DrawCopyRegion(){
//             EditorGUILayout.BeginVertical();

//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.LabelField ("Copy Local");
//             if (GUILayout.Button("Position"))
//                 EditorGUIUtility.systemCopyBuffer = _positionProp.ToString();
//             if (GUILayout.Button("Rotation"))
//                 _positionProp.vector3Value = Vector3.zero;
//             if (GUILayout.Button("Scale"))
//                 _positionProp.vector3Value = Vector3.zero;
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.LabelField ("Copy World");
//             if (GUILayout.Button("Position"))
//                 _positionProp.vector3Value = EditorGUIUtility.systemCopyBuffer;
//             if (GUILayout.Button("Rotation"))
//                 _positionProp.vector3Value = Vector3.zero;
//             if (GUILayout.Button("Scale"))
//                 _positionProp.vector3Value = Vector3.zero;
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.BeginHorizontal();
//             EditorGUILayout.LabelField ("Paste");
//             if (GUILayout.Button("Position"))
//                 _positionProp.vector3Value = Vector3.zero;
//             if (GUILayout.Button("Rotation"))
//                 _positionProp.vector3Value = Vector3.zero;
//             if (GUILayout.Button("Scale"))
//                 _positionProp.vector3Value = Vector3.zero;
//             EditorGUILayout.EndHorizontal();

//             EditorGUILayout.EndVertical();
//         }
//     }
// }
