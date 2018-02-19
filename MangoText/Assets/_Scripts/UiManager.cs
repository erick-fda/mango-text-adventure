/*========================================================================================
    UiManager                                                                        *//**
	
    Manages access to the UI canvas.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/*========================================================================================
	Enums
========================================================================================*/
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
	MyMonoBehaviour
========================================================================================*/
namespace MangoText
{
public class UiManager : MonoBehaviour
{
	/*----------------------------------------------------------------------------------------
		Static Fields
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
    public const string MovementButtonUpHint = "w";
    public const string MovementButtonDownHint = "s";
    public const string MovementButtonLeftHint = "a";
    public const string MovementButtonRightHint = "d";

	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
    public Text _mainText;
    public List<ActionButton> _actionButtons;
    public ScreenContent _nullScreenContent;

    private ScreenContent _screenContent;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
    /* The content for UI elements such as text, images, and buttons. */
    public ScreenContent ScreenContent
    {
        get { return _screenContent; }

        set
        {
            if (null == value)
            {
                value = _nullScreenContent;
            }

            _screenContent = value;
            MainText = value.MainText;

            UpdateActionButtons();
        }
    }

    /* The main text area. */
	private string MainText
    {
        get { return _mainText.text; }

        set { _mainText.text = value; }
    }
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CheckInvariant();
        GameManager.Instance.Ui = this;
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Check for invalid field values.
    */
    private void CheckInvariant()
    {
        if (null == _mainText)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _mainText is not permitted to be null.");
        }

        if (null == _actionButtons || 
            _actionButtons.Count < 15)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _actionButtons is not premitted to be null or have missing elements.");
        }
    }

    /**
        Updates the text and appearance of action buttons based on the current screen content.
    */
    private void UpdateActionButtons()
    {
        /* Include movement buttons if the player can move. */
        if (ScreenContent._canPlayerMove)
        {
            for (int i = 0; i < _actionButtons.Count; i++)
            {
                /* If this is a movement button. */
                if ( System.Array.IndexOf(System.Enum.GetValues(typeof(MovementButtonIndex)), (MovementButtonIndex)i) > -1 )
                {
                    UpdateMovementButton(i);
                }
                else
                {
                    UpdateSingleActionButton(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < _actionButtons.Count; i++)
            {
                UpdateSingleActionButton(i);
            }
        }
    }

    /**
        Updates the the movement button with the given index.
    */
    private void UpdateMovementButton(int index)
    {
        switch ((MovementButtonIndex)index)
        {
            case MovementButtonIndex.Up :
                _actionButtons[index].SetText(MovementButtonUpMainText, 
                    MovementButtonUpHint);
                break;

            case MovementButtonIndex.Down :
                _actionButtons[index].SetText(MovementButtonDownMainText, 
                    MovementButtonDownHint);
                break;

            case MovementButtonIndex.Left :
                _actionButtons[index].SetText(MovementButtonLeftMainText, 
                    MovementButtonLeftHint);
                break;

            case MovementButtonIndex.Right :
                _actionButtons[index].SetText(MovementButtonRightMainText, 
                    MovementButtonRightHint);
                break;

            default :
                throw new System.ArgumentException(string.Format(
                    "UiManager.UpdateMovementButton: {0} is not a valid movement button index.", index), "index");
        }

        ActionButton button = _actionButtons[index];
        button.Color = Constants.ActionButtonMovementColor;
        button.HintAreaColor = Constants.ActionButtonMovementHintColor;
    }

    /**
        Updates the action button with the given index.
    */
    private void UpdateSingleActionButton(int index)
    {
        ActionButton button = _actionButtons[index];
        button.SetText(string.Empty, string.Empty);
        button.Color = Constants.ActionButtonInactiveColor;
        button.HintAreaColor = Constants.ActionButtonInactiveHintColor;
    }
}}
