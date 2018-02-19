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
	private const string _adjacentUpPropertyName = "_adjacentUp";
	private const string _adjacentDownPropertyName = "_adjacentDown";
	private const string _adjacentLeftPropertyName = "_adjacentLeft";
	private const string _adjacentRightPropertyName = "_adjacentRight";
    private const string _screenContentPropertyName = "_screenContent";
	private const string _armUpPropertyName = "_armUp";
	private const string _armDownPropertyName = "_armDown";
	private const string _armLeftPropertyName = "_armLeft";
	private const string _armRightPropertyName = "_armRight";

    private SerializedProperty _adjacentUpProperty;
    private SerializedProperty _adjacentDownProperty;
    private SerializedProperty _adjacentLeftProperty;
    private SerializedProperty _adjacentRightProperty;
    private SerializedProperty _screenContentProperty;
    private SerializedProperty _armUpProperty;
    private SerializedProperty _armDownProperty;
    private SerializedProperty _armLeftProperty;
    private SerializedProperty _armRightProperty;

    private const string _adjacentNodesFoldoutLabel = "Adjacent Nodes";
    private const string _armsFoldoutLabel = "Arms";
    private static readonly GUIContent _adjacentUpPropertyLabel = new GUIContent("Up");
    private static readonly GUIContent _adjacentDownPropertyLabel = new GUIContent("Down");
    private static readonly GUIContent _adjacentLeftPropertyLabel = new GUIContent("Left");
    private static readonly GUIContent _adjacentRightPropertyLabel = new GUIContent("Right");

    private bool _showAdjacentNodesFoldout = true;
    private bool _showArmsFoldout = false;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	
    
	/*----------------------------------------------------------------------------------------
		Editor Methods
	----------------------------------------------------------------------------------------*/
    private void OnEnable()
    {
        _adjacentUpProperty = serializedObject.FindProperty(_adjacentUpPropertyName);
        _adjacentDownProperty = serializedObject.FindProperty(_adjacentDownPropertyName);
        _adjacentLeftProperty = serializedObject.FindProperty(_adjacentLeftPropertyName);
        _adjacentRightProperty = serializedObject.FindProperty(_adjacentRightPropertyName);
        _screenContentProperty = serializedObject.FindProperty(_screenContentPropertyName);
        _armUpProperty = serializedObject.FindProperty(_armUpPropertyName);
        _armDownProperty = serializedObject.FindProperty(_armDownPropertyName);
        _armLeftProperty = serializedObject.FindProperty(_armLeftPropertyName);
        _armRightProperty = serializedObject.FindProperty(_armRightPropertyName);
    }

    public override void OnInspectorGUI ()
    {
        serializedObject.Update();
        
        DrawAdjacentNodeList();
        EditorGUILayout.Space();

        DrawContentField();
        EditorGUILayout.Space();

        DrawArmList();

        serializedObject.ApplyModifiedProperties();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Draws a foldout list with property fields for the MapNode's arms.
    */
    private void DrawArmList()
    {
        EditorGUILayout.BeginVertical();
        
        _showArmsFoldout = EditorGUILayout.Foldout(_showArmsFoldout, _armsFoldoutLabel, true);

        if (_showArmsFoldout)
        {
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_armUpProperty);
            EditorGUILayout.PropertyField(_armDownProperty);
            EditorGUILayout.PropertyField(_armLeftProperty);
            EditorGUILayout.PropertyField(_armRightProperty);

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical ();
    }

    /**
        Draws a foldout list with property fields for the MapNode's adjacent nodes.
    */
    private void DrawAdjacentNodeList()
    {
        EditorGUILayout.BeginVertical();
        
        _showAdjacentNodesFoldout = EditorGUILayout.Foldout(_showAdjacentNodesFoldout, _adjacentNodesFoldoutLabel, true);

        if (_showAdjacentNodesFoldout)
        {
            EditorGUI.indentLevel++;
            
            EditorGUILayout.PropertyField(_adjacentUpProperty, _adjacentUpPropertyLabel);
            EditorGUILayout.PropertyField(_adjacentDownProperty, _adjacentDownPropertyLabel);
            EditorGUILayout.PropertyField(_adjacentLeftProperty, _adjacentLeftPropertyLabel);
            EditorGUILayout.PropertyField(_adjacentRightProperty, _adjacentRightPropertyLabel);
            
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndVertical ();
    }

    /**
        Draws a property field for the map node's content.
    */
    private void DrawContentField()
    {
        EditorGUILayout.PropertyField(_screenContentProperty);
    }
}}
