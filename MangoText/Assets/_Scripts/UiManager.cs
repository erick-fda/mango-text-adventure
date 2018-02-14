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
    public ScreenContent _nullScreenContent;

    private ScreenContent _content;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
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
        GameManager.Instance.Ui = this;
        CheckForNullReferences();
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

        //MainText = content.MainText;
    }

    /**
        Checks for null values in fields not permitted to be null.
    */
    private void CheckForNullReferences()
    {
        if (null == _mainText)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _mainText is not permitted to be null.");
        }
    }
}}
