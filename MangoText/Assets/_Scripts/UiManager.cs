﻿/*========================================================================================
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

    private ScreenContent _content;
    
	/*----------------------------------------------------------------------------------------
		Instance Properties
	----------------------------------------------------------------------------------------*/
	public string MainText
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
    private void CheckForNullReferences()
    {
        if (_mainText == null)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _mainText is not permitted to be null.");
        }
    }
}}
