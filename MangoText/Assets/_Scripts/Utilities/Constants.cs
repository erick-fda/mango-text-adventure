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
    /*
        Enum of scene indeces.
    */
    public enum SceneId : int
    {
        PersistentScene,
        TestScene01,
    }

    /*
        Enum of screen content IDs.
    */
    public enum ScreenContentId
    {
        Null,
        Test01,
    }

    /*
        Enum of movement button indices.
    */
    public enum MovementButtonIndex : int
    {
        Up = 6, 
        Left = 10, 
        Down = 11, 
        Right = 12,
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
            Action button main texts.
        */
        public const string MovementButtonUpMainText = "North";
        public const string MovementButtonDownMainText = "South";
        public const string MovementButtonLeftMainText = "West";
        public const string MovementButtonRightMainText = "East";

        /*
            Action button keyboard hints.
        */
        public const string MovementButtonUpKeyboardHint = "w";
        public const string MovementButtonDownKeyboardHint = "s";
        public const string MovementButtonLeftKeyboardHint = "a";
        public const string MovementButtonRightKeyboardHint = "d";

        /*----------------------------------------------------------------------------------------
            Collections
        ----------------------------------------------------------------------------------------*/
        /*
            Map of screen content names to filenames.
        */
        static public readonly Dictionary<ScreenContentId, string> ScreenContentMainTextFilePath = 
            new Dictionary<ScreenContentId, string>()
        {
            { ScreenContentId.Null, "ScreenContents/sc_null.txt" },
            { ScreenContentId.Test01, "ScreenContents/test01text.txt" },
        };
}}
