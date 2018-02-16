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
    public Text _keyboardHintText;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	public string MainText
    {
        get { return _mainText.text; }
        set { _mainText.text = value; }
    }

    public string KeyboardHintText
    {
        get { return _keyboardHintText.text; }
        set { _keyboardHintText.text = value; }
    }
    
	/*----------------------------------------------------------------------------------------
		MonoBehaviour Methods
	----------------------------------------------------------------------------------------*/
    /**
        Sets the main and keyboard hint text for this action button.
    */
    public void SetText(string mainText, string keyboardHintText)
    {
        MainText = mainText;
        KeyboardHintText = keyboardHintText;
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
	
}}
