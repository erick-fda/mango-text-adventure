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
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
	/**
        Enables arms that connect to other nodes and disables those that do not.
    */
    private void UpdateArms()
    {
        _armUp.SetActive(_adjacentUp != null);
        _armDown.SetActive(_adjacentDown != null);
        _armLeft.SetActive(_adjacentLeft != null);
        _armRight.SetActive(_adjacentRight != null);
    }
}}
