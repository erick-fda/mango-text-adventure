/*========================================================================================
    MapNodeEditor                                                                    *//**
	
    Custom editor for a MapNode.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;
using UnityEditor;

/*========================================================================================
	MapNodeEditor
========================================================================================*/
namespace MangoText
{
[CustomEditor(typeof(MapNode))]
[CanEditMultipleObjects]
public class MapNodeEditor : Editor
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	private const string _armUpPropertyName = "_armUp";
	private const string _armDownPropertyName = "_armDown";
	private const string _armLeftPropertyName = "_armLeft";
	private const string _armRightPropertyName = "_armRight";
	private const string _adjacentUpPropertyName = "_adjacentUp";
	private const string _adjacentDownPropertyName = "_adjacentDown";
	private const string _adjacentLeftPropertyName = "_adjacentLeft";
	private const string _adjacentRightPropertyName = "_adjacentRight";

    private SerializedProperty _armUpProperty;
    private SerializedProperty _armDownProperty;
    private SerializedProperty _armLeftProperty;
    private SerializedProperty _armRightProperty;
    private SerializedProperty _adjacentUpProperty;
    private SerializedProperty _adjacentDownProperty;
    private SerializedProperty _adjacentLeftProperty;
    private SerializedProperty _adjacentRightProperty;

    private bool _showArmFields = false;
    private bool _showAdjacentNodeFields = true;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	
    
	/*----------------------------------------------------------------------------------------
		Editor Methods
	----------------------------------------------------------------------------------------*/
    private void OnEnable()
    {
        _armUpProperty = serializedObject.FindProperty(_armUpPropertyName);
        _armDownProperty = serializedObject.FindProperty(_armDownPropertyName);
        _armLeftProperty = serializedObject.FindProperty(_armLeftPropertyName);
        _armRightProperty = serializedObject.FindProperty(_armRightPropertyName);
        _adjacentUpProperty = serializedObject.FindProperty(_adjacentUpPropertyName);
        _adjacentDownProperty = serializedObject.FindProperty(_adjacentDownPropertyName);
        _adjacentLeftProperty = serializedObject.FindProperty(_adjacentLeftPropertyName);
        _adjacentRightProperty = serializedObject.FindProperty(_adjacentRightPropertyName);
    }

    public override void OnInspectorGUI ()
    {
        serializedObject.Update ();
        
        DrawArmList();
        DrawAdjacentNodeList();

        serializedObject.ApplyModifiedProperties ();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Draws a foldout list with property fields for the MapNode's arms.
    */
    private void DrawArmList()
    {
        EditorGUILayout.BeginVertical (GUI.skin.box);
        EditorGUI.indentLevel++;
        
            _showArmFields = EditorGUILayout.Foldout(_showArmFields, "Arms");

            if (_showArmFields)
            {
                EditorGUILayout.PropertyField(_armUpProperty);
                EditorGUILayout.PropertyField(_armDownProperty);
                EditorGUILayout.PropertyField(_armLeftProperty);
                EditorGUILayout.PropertyField(_armRightProperty);
            }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical ();
    }

    /**
        Draws a foldout list with property fields for the MapNode's adjacent nodes.
    */
    private void DrawAdjacentNodeList()
    {
        EditorGUILayout.BeginVertical (GUI.skin.box);
        EditorGUI.indentLevel++;
        
            _showAdjacentNodeFields = EditorGUILayout.Foldout(_showAdjacentNodeFields, "Adjacent Nodes");

            if (_showAdjacentNodeFields)
            {
                EditorGUILayout.PropertyField(_adjacentUpProperty);
                EditorGUILayout.PropertyField(_adjacentDownProperty);
                EditorGUILayout.PropertyField(_adjacentLeftProperty);
                EditorGUILayout.PropertyField(_adjacentRightProperty);
            }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical ();
    }
}}
