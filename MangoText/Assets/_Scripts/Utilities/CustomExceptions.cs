/*========================================================================================
    CustomExceptions                                                                 *//**
	
	Namespace for custom exception types.
	
    Copyright 2017 Erick Fernandez de Arteaga. All rights reserved.
        https://www.linkedin.com/in/erick-fda
        https://bitbucket.org/erick-fda
	
*//*====================================================================================*/

/*========================================================================================
	Dependencies
========================================================================================*/
using System;

/*========================================================================================
	CustomExceptions
========================================================================================*/
namespace CustomExceptions
{
    /**
        Exception due to manually creating a singleton MonoBehaviour by including it in 
        a scene hierarchy.
    */
    public class IllegalSingletonException : Exception
    {
        public IllegalSingletonException() { }
        public IllegalSingletonException(string message) : base(message) { }
        public IllegalSingletonException(string message, Exception innerException) : base(message, innerException) { }
    }
}
