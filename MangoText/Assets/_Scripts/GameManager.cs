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
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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
    public SceneId _initialScene;
    public int _initialSceneNode;

	private UiManager _uiManager;
    private MapCamera _mapCamera;
    private MapNode _currentNode;
    private int _nextStartNodeIndex;
    private ScreenContent _screenContent;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
    /**
        The map node that currently has the focus.
    */
    public MapNode CurrentNode
    {
        get { return _currentNode; }

        set
        {
            if (value == null)
            {
                throw new System.ArgumentNullException("value", "GameManager.CurrentNode.set: CurrentNode cannot be set to null.");
            }

            _currentNode = value;
            _screenContent = _currentNode.ScreenContent;

            Ui.ScreenContent = _currentNode.ScreenContent;

            MapCamera.transform.position = new Vector3(
                _currentNode.transform.position.x, _currentNode.transform.position.y, MapCamera.transform.position.z);
        }
    }

    /**
        The camera that captures the map image.
    */
    public MapCamera MapCamera
    {
        get { return _mapCamera; }

        set
        {
            if (_mapCamera != null)
            {
                throw new System.InvalidOperationException(
                    "GameManager.MapCamera.set: MapCamera is only permitted to be set when it is null.");
            }

            _mapCamera = value;
        }
    }

    /**
        The index of the map node to receive the focus when the next scene is loaded.
    */
    public int NextStartNodeIndex
    {
        get { return _nextStartNodeIndex; }

        private set
        {
            if (value < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    "value", "GameManager.NextStartNode.set: NextStartNode must be non-negative.");
            }

            _nextStartNodeIndex = value;
        }
    }

    /* The GameObject that manages UI. */
    public UiManager Ui
    {
        get { return _uiManager; }

        set
        {
            if (_uiManager != null)
            {
                throw new System.InvalidOperationException(
                    "GameManager.Ui.set: Ui is only permitted to be set when it is null.");
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
        LoadScene(_initialScene, _initialSceneNode);
    }
    
	private void OnDestroy()
    {
        EnforceSingletonDestruction(this);
    }

	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Loads the scene with the given ID and places the player at the start node with the 
        given index.
    */
    private void LoadScene(SceneId sceneID, int startNodeIndex)
    {
        NextStartNodeIndex = startNodeIndex;
        SceneManager.LoadScene((int)sceneID);
    }

    /**
        Moves the player to the adjacent node in the given direction if it exists and is 
        accessible.
    */
    public void Move(MoveDirection direction)
    {
        /* Do nothing if the player can't move from the current screen. */
        if (false == _screenContent._canPlayerMove)
        {
            return;
        }

        MapNode nodeToMoveTo;

        switch(direction)
        {
            case MoveDirection.Up :
                nodeToMoveTo = CurrentNode._adjacentUp;
                break;

            case MoveDirection.Down :
                nodeToMoveTo = CurrentNode._adjacentDown;
                break;

            case MoveDirection.Left :
                nodeToMoveTo = CurrentNode._adjacentLeft;
                break;

            case MoveDirection.Right :
                nodeToMoveTo = CurrentNode._adjacentRight;
                break;

            default :
                throw new System.ArgumentException(
                    "GameManager.Move: Parameter direction was not a valid MoveDirection value.", "direction");
        }

        if (null != nodeToMoveTo)
        {
            CurrentNode = nodeToMoveTo;
        }
    }
}}
