/*========================================================================================
    MapNode                                                                          *//**
	
    A node in a level map.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;

/*========================================================================================
	MapNode
========================================================================================*/
namespace MangoText
{
[ExecuteInEditMode]
public class MapNode : MonoBehaviour
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	public GameObject _armUp;
	public GameObject _armDown;
	public GameObject _armLeft;
	public GameObject _armRight;

    public MapNode _adjacentUp;
    public MapNode _adjacentDown;
    public MapNode _adjacentLeft;
    public MapNode _adjacentRight;

    public ScreenContent _content;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    private void Awake()
    {
        UpdateArms();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            UpdateArms();
        }
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
	/**
        Updates all adjacent nodes and arms.

        For every null node, the arm that connects to it is set inactive.
        
        For every non-null node, the arm that connects to it and its corresponding arm 
        are both set active.
    */
    private void UpdateArms()
    {
        GameObject adjacentNodeArm;

        /* Update arm up. */
        adjacentNodeArm = (_adjacentUp == null) ? null : _adjacentUp._armDown;
        UpdateSingleArm(_armUp, _adjacentUp, adjacentNodeArm);

        /* Update arm down. */
        adjacentNodeArm = (_adjacentDown == null) ? null : _adjacentDown._armUp;
        UpdateSingleArm(_armDown, _adjacentDown, adjacentNodeArm);
        
        /* Update arm left. */
        adjacentNodeArm = (_adjacentLeft == null) ? null : _adjacentLeft._armRight;
        UpdateSingleArm(_armLeft, _adjacentLeft, adjacentNodeArm);
        
        /* Update arm right. */
        adjacentNodeArm = (_adjacentRight == null) ? null : _adjacentRight._armLeft;
        UpdateSingleArm(_armRight, _adjacentRight, adjacentNodeArm);
    }

    /**
        Updates the given arm, adjacent node, and corresponding adjacent node arm.

        If the node is null, the arm that connects to it is set inactive.
        
        If the node is not null, the arm that connects to it and its corresponding arm 
        are both set active.
    */
    private void UpdateSingleArm(GameObject arm, MapNode adjacentNode, GameObject adjacentNodeArm)
    {
        if (adjacentNode == null)
        {
            arm.SetActive(false);
        }
        else
        {
            arm.SetActive(true);
            adjacentNodeArm.SetActive(true);
        }
    }
}}
