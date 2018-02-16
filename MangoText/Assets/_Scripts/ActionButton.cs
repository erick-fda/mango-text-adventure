/*========================================================================================
    ActionButton                                                                     *//**
	
    A button used to perform an action, such as moving or speaking to an NPC.
	
    Copyright 2018 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using UnityEngine;
using UnityEngine.UI;

/*========================================================================================
	ActionButton
========================================================================================*/
namespace MangoText
{
public class ActionButton : MonoBehaviour
{
	/*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	public Text _mainText;
    public Image _hintArea;
    public Text _hintText;

    private Image _mainArea;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	/* The button's main text. */
    public string MainText
    {
        get { return _mainText.text; }
        set { _mainText.text = value; }
    }

    /* The color of the main button area. */
    public Color Color
    {
        get { return _mainArea.color; }
        set { _mainArea.color = value; }
    }

    /* The color of the keyboard hint image area. */
    public Color HintAreaColor
    {
        get { return _hintArea.color; }
        set { _hintArea.color = value; }
    }

    /* The button's keyboard hint text. */
    public string KeyboardHintText
    {
        get { return _hintText.text; }
        set { _hintText.text = value; }
    }
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    private void Awake()
    {
        _mainArea = GetComponent<Image>();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Sets the main and keyboard hint text for this action button.
    */
    public void SetText(string mainText, string hintText)
    {
        MainText = mainText;
        KeyboardHintText = hintText;
    }
}}
