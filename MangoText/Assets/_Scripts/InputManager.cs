/*========================================================================================
    InputManager                                                                     *//**
	
    Handles user input.
	
    Copyright 2018 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;
using System.Collections.Generic;

/*========================================================================================
	Enums
========================================================================================*/
/*
    Enum of keyboard input names.
*/
public enum Key
{
    MoveUp,
    MoveDown,
    MoveLeft, 
    MoveRight,
}

/*========================================================================================
	InputManager
========================================================================================*/
namespace MangoText
{
public class InputManager : MonoBehaviour
{
	/*----------------------------------------------------------------------------------------
		Static Fields
	----------------------------------------------------------------------------------------*/
    /*
        Dictionary of keyboard input names to keycodes.
    */
    static public readonly Dictionary<Key, KeyCode> KeyCodeForKey = 
        new Dictionary<Key, KeyCode>()
    {
        { Key.MoveUp, KeyCode.W },
        { Key.MoveDown, KeyCode.S },
        { Key.MoveLeft, KeyCode.A },
        { Key.MoveRight, KeyCode.D },
    };

	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        GetMovementInput();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
	/**
        Handles input for moving the player.
    */
    private void GetMovementInput()
    {
        /* Move up. */
        if (Input.GetKeyDown(KeyCodeForKey[Key.MoveUp]))
        {
            GameManager.Instance.Move(MoveDirection.Up);
        }
        
        /* Move down. */
        if (Input.GetKeyDown(KeyCodeForKey[Key.MoveDown]))
        {
            GameManager.Instance.Move(MoveDirection.Down);
        }
        
        /* Move left. */
        if (Input.GetKeyDown(KeyCodeForKey[Key.MoveLeft]))
        {
            GameManager.Instance.Move(MoveDirection.Left);
        }
        
        /* Move right. */
        if (Input.GetKeyDown(KeyCodeForKey[Key.MoveRight]))
        {
            GameManager.Instance.Move(MoveDirection.Right);
        }
    }
}}
