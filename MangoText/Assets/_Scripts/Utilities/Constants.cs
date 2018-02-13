/*========================================================================================
    Constants                                                                        *//**
	
    Namespace for global constants.
	
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
	Global Constants
========================================================================================*/
namespace MangoText
{
    /*----------------------------------------------------------------------------------------
        Enums
    ----------------------------------------------------------------------------------------*/
    /**
        Enum of scene indeces.
    */
    public enum SceneId : int
    {
        PersistentScene,
        TestScene01,
    }

    /*----------------------------------------------------------------------------------------
        Screen Contents
    ----------------------------------------------------------------------------------------*/
    /**
        Enum of screen content IDs.
    */
    public enum ScreenContentId : int
    {
        Test01,
    }

    /*========================================================================================
        Class Constants
    ========================================================================================*/
    public static class Constants
    {
        /*----------------------------------------------------------------------------------------
            Screen Contents
        ----------------------------------------------------------------------------------------*/
        /**
            Map of screen content names to filenames.
        */
        static public readonly Dictionary<ScreenContentId, string> ScreenContentFilename = 
            new Dictionary<ScreenContentId, string>()
        {
            { ScreenContentId.Test01, "ScreenContents/test01text" },
        };
}}
