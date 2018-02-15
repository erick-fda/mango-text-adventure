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
	MyMonoBehaviour
========================================================================================*/
namespace MangoText
{
public class UiManager : MonoBehaviour
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
    public Text _mainText;
    public List<Button> _actionButtons;
    public ScreenContent _nullScreenContent;

    private ScreenContent _screenContent;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
    /**
        The content for UI elements such as text, images, and buttons.
    */
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
        }
    }

    /**
        The main text area.
    */
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
        UpdateActionButtons();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Sets the content of UI elements based on the content object passed in.
    */
    public void SetScreenContent(ScreenContent content)
    {
        if (null == content)
        {
            content = _nullScreenContent;
        }

        MainText = content.MainText;
    }

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

    }
}}
