/*========================================================================================
    ScreenContent                                                                    *//**
	
    A ScriptableObject that defines the content for a game screen.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
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
    Enum of screen content IDs.
*/
public enum ScreenContentId
{
    Null,
    Test01,
}

/*========================================================================================
	ScreenContent
========================================================================================*/
namespace MangoText
{
[CreateAssetMenu(fileName = "NewScreenContent.asset", menuName = "Screen Content")]
public class ScreenContent : ScriptableObject
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	public ScreenContentId _id;
    public bool _canPlayerMove = true;
    public List<ActionButtonContent> _actionButtonContents;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	/**
        Getter for the main text of this screen content.
    */
    public string MainText
    {
        get
        {
            return System.IO.File.ReadAllText(
                System.IO.Path.Combine(
                    Application.streamingAssetsPath, 
                    Constants.ScreenContentMainTextFilePath[_id]));
        }
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
	
}}
