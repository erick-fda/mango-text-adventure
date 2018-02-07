/*========================================================================================
    GameManager                                                                      *//**
	
    Manages game initalization and dialogue stacks.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;

/*========================================================================================
	GameManager
========================================================================================*/
namespace MangoText
{
public class GameManager : SingletonMonoBehaviour<GameManager>
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	private UiManager _uiManager;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
    public UiManager Ui
    {
        get { return _uiManager; }

        set
        {
            if (_uiManager != null)
            {
                throw new System.InvalidOperationException(
                    "GameManager.UiManager.set: UiManager is only permitted to be set when it is null.");
            }

            _uiManager = value;
        }
    }
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    private void Awake()
    {
        EnforceSingletonCreation(this);
    }

    private void Start()
    {
        CheckForNulls();
    }
    
	private void OnDestroy()
    {
        EnforceSingletonDestruction(this);
    }

	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    private void CheckForNulls()
    {
        if (Ui == null)
        {
            throw new System.NullReferenceException(
                "GameManager.CheckForNulls: UiManager is not permitted to be null.");
        }
    }
}}
