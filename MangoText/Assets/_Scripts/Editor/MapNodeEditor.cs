﻿/*========================================================================================
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

    private bool _showAdjacentNodeFields = true;
    private bool _showArmFields = false;
    
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
        
        _showArmFields = EditorGUILayout.Foldout(_showArmFields, "Arms");

        if (_showArmFields)
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
        
        _showAdjacentNodeFields = EditorGUILayout.Foldout(_showAdjacentNodeFields, "Adjacent Nodes");

        if (_showAdjacentNodeFields)
        {
            EditorGUI.indentLevel++;
            
            EditorGUILayout.PropertyField(_adjacentUpProperty, new GUIContent("Up"));
            EditorGUILayout.PropertyField(_adjacentDownProperty, new GUIContent("Down"));
            EditorGUILayout.PropertyField(_adjacentLeftProperty, new GUIContent("Left"));
            EditorGUILayout.PropertyField(_adjacentRightProperty, new GUIContent("Right"));
            
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
