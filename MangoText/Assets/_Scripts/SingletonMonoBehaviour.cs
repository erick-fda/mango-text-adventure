/*========================================================================================
    SingletonMonoBehaviour<T>                                                        *//**
	
	Abstract superclass for singleton MonoBehaviours.
	
    Copyright 2018 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using System;
using UnityEngine;

/*========================================================================================
	SingletonMonoBehaviour<T>
========================================================================================*/
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour
    where T : SingletonMonoBehaviour<T>
{
    /*----------------------------------------------------------------------------------------
		Class Fields
	----------------------------------------------------------------------------------------*/
    private static T _instance = null;

    /*----------------------------------------------------------------------------------------
		Class Properties
	----------------------------------------------------------------------------------------*/
	/**
        Readonly property indicating whether the singleton is accessible.

        This property will return false before initialization and after the singleton has 
        been flagged for destruction. Accessing this property will not trigger singleton 
        initialization.
        
        This property should first be checked by any object that wants to access a 
        singleton during OnDestroy() or OnApplicationQuit(). If this returns false, the 
        singleton instance should not be accessed; doing so will lead to broken scene 
        hierarchies and memory leaks!
     */
    public static bool IsAlive
    {
        get
        {
            if (!_instance)
            {
                return false;
            }
            else
            {
                return _instance._isAlive;
            }
        }
    }

	/**
        Singleton instance access property for subclasses.
        Subclasses should define their own "Instance" property for accessing this one.

        On initialization, if any instances of the singleton are found that were not 
        created within the class (such as any included in an Editor scene hierarchy), 
        an IllegalSingletonMonoBehaviourException is thrown.

        @throws IllegalSingletonException - If any singleton instances not created by the 
                    class are found.
     */
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>();
            }

            return _instance;
        }
    }

    /*----------------------------------------------------------------------------------------
		Instance Fields
	----------------------------------------------------------------------------------------*/
	private bool _isAlive = false;

	/*----------------------------------------------------------------------------------------
		Instance Methods
	----------------------------------------------------------------------------------------*/
    /**
        Enforces the singleton pattern when an instance is created.
        Subclasses should call this method in their Awake() methods.

        @param candidate - The subclass instance calling this method.
    */
    protected void EnforceSingletonCreation(T candidate)
    {
        if (!_instance)
        {
            _instance = candidate;
            _isAlive = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != candidate)
        {
            Destroy(candidate.gameObject);
        }
    }

    /**
        Enforces the singleton pattern when an instance is destroyed.
        Subclasses should call this method in their OnDestroy() methods.

        @param candidate - The subclass instance calling this method.
    */
    protected void EnforceSingletonDestruction(T candidate)
    {
        if (_instance == candidate)
        {
            _instance = null;
            _isAlive = false;
        }
    }
}
