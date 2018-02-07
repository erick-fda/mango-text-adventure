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
	public Canvas _mainCanvas;
    public Text _mainText;
    
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
        GameManager.Instance.Ui = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(_mainCanvas);
    }

    private void Start()
    {
        CheckForNullReferences();
    }
    
	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    private void CheckForNullReferences()
    {
        if (_mainCanvas == null)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _mainCanvas is not permitted to be null.");
        }

        if (_mainText == null)
        {
            throw new System.NullReferenceException(
                "UiManager.CheckForNullReferences: _mainText is not permitted to be null.");
        }
    }
}}
