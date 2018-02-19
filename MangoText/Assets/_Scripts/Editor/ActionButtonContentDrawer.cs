/*========================================================================================
    ActionButtonContentDrawer                                                        *//**
	
    Custom property drawer for an ActionButtonContent.
	
    Copyright 2018 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;
using UnityEditor;

/*========================================================================================
    ActionButtonContentDrawer
========================================================================================*/
namespace MangoText
{
[CustomPropertyDrawer(typeof(ActionButtonContent))]
public class ActionButtonContentDrawer : PropertyDrawer
{
    /*----------------------------------------------------------------------------------------
        Static Fields
    ----------------------------------------------------------------------------------------*/
    private static readonly float _maxDrawerHeight = EditorGUIUtility.singleLineHeight * 2;

    private const string _mainTextPropertyName = "_mainText";
    private const string _hintTextPropertyName = "_hintText";

    private static readonly GUIContent _mainTextPropertyLabel = new GUIContent("Main Text");
    private static readonly GUIContent _hintTextPropertyLabel = new GUIContent("Hint Text");

    /*----------------------------------------------------------------------------------------
        Instance Fields
    ----------------------------------------------------------------------------------------*/
    
    
    /*----------------------------------------------------------------------------------------
        Instance Properties
    ----------------------------------------------------------------------------------------*/
    
    
    /*----------------------------------------------------------------------------------------
        PropertyDrawer Methods
    ----------------------------------------------------------------------------------------*/
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int externalIndentLevel = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, GUIContent.none);

        if (property.isExpanded)
        {
            /* Main text */
            Rect mainTextRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(mainTextRect, property.FindPropertyRelative(_mainTextPropertyName), _mainTextPropertyLabel);

            /* Hint text */
            Rect hintTextRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(hintTextRect, property.FindPropertyRelative(_hintTextPropertyName), _hintTextPropertyLabel);
        }

        EditorGUI.indentLevel = externalIndentLevel;
        EditorGUI.EndProperty();
    }

    /**
        Returns the height of the ActionButtonContentDrawer rect.
    */
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
        {
            return _maxDrawerHeight;
        }
        else
        {
            return EditorGUIUtility.singleLineHeight;
        }
    }
    
    /*----------------------------------------------------------------------------------------
        Instance Methods
    ----------------------------------------------------------------------------------------*/
    
}}
