﻿/*========================================================================================
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
    /*
        Enum of scene indeces.
    */
    public enum SceneId : int
    {
        PersistentScene,
        TestScene01,
    }

    /*
        Enum of move directions.
    */
    public enum MoveDirection
    {
        Up, 
        Down, 
        Left, 
        Right,
    }

    /*========================================================================================
        Class Constants
    ========================================================================================*/
    public static class Constants
    {
        /*----------------------------------------------------------------------------------------
            Consts
        ----------------------------------------------------------------------------------------*/
        /*
            Colors
        */
        public static readonly Color ActionButtonMovementColor = new Color(0.2f, 0.2f, 0.5f);
        public static readonly Color ActionButtonMovementHintColor = new Color(0.25f, 0.25f, 0.6f);
        public static readonly Color ActionButtonInactiveColor = new Color(0.2f, 0.2f, 0.3f);
        public static readonly Color ActionButtonInactiveHintColor = new Color(0.25f, 0.25f, 0.35f);

        /*----------------------------------------------------------------------------------------
            Collections
        ----------------------------------------------------------------------------------------*/
        /*
            Dictionary of screen content names to filenames.
        */
        public static readonly Dictionary<ScreenContentId, string> ScreenContentMainTextFilePath = 
            new Dictionary<ScreenContentId, string>()
        {
            { ScreenContentId.Null, "ScreenContents/sc_null.txt" },
            { ScreenContentId.Test01, "ScreenContents/test01text.txt" },
        };
    }
}
