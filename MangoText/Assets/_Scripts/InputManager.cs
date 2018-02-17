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

/*========================================================================================
	InputManager
========================================================================================*/
namespace MangoText
{
public class InputManager : MonoBehaviour
{
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
        if (Input.GetKeyDown(Constants.KeyCodeForKey[Key.MoveUp]))
        {
            GameManager.Instance.Move(MoveDirection.Up);
        }
        
        /* Move down. */
        if (Input.GetKeyDown(Constants.KeyCodeForKey[Key.MoveDown]))
        {
            GameManager.Instance.Move(MoveDirection.Down);
        }
        
        /* Move left. */
        if (Input.GetKeyDown(Constants.KeyCodeForKey[Key.MoveLeft]))
        {
            GameManager.Instance.Move(MoveDirection.Left);
        }
        
        /* Move right. */
        if (Input.GetKeyDown(Constants.KeyCodeForKey[Key.MoveRight]))
        {
            GameManager.Instance.Move(MoveDirection.Right);
        }
    }
}}
