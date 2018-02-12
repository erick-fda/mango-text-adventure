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
using MangoText.Constants;

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
                    "GameManager.Ui.set: Ui is only permitted to be set when it is null.");
            }

            _uiManager = value;
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

            MapCamera.transform.position = new Vector3(
                _currentNode.transform.position.x, _currentNode.transform.position.y, MapCamera.transform.position.z);
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

    private void Update()
    {
        Move();
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
        Moves the player to an adjacent node if appropriate input is received.
    */
    private void Move()
    {
        /* Move up. */
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CurrentNode._adjacentUp != null)
            {
                CurrentNode = CurrentNode._adjacentUp;
                return;
            }
        }
        
        /* Move down. */
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CurrentNode._adjacentDown != null)
            {
                CurrentNode = CurrentNode._adjacentDown;
                return;
            }
        }
        
        /* Move left. */
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CurrentNode._adjacentLeft != null)
            {
                CurrentNode = CurrentNode._adjacentLeft;
                return;
            }
        }
        
        /* Move right. */
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (CurrentNode._adjacentRight != null)
            {
                CurrentNode = CurrentNode._adjacentRight;
                return;
            }
        }
    }
}}
