﻿using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using log4net;

namespace testingunmanagedexceptionhandler
{
    class Program
    {
        /// <summary>
        /// Create a reference from unmanaged FailingApp.dll C++ code.
        /// </summary>
        /// <returns>Reference.</returns>        
        [DllImport("..\\..\\failinglibrary.dll")]
        private static extern int CreateReference();
        static void Main(string[] args)
        {
            Console.ReadKey();
            for (int t = 0; t <= 1; t++)
            {
                Logging.Info("Starting with handler:");
                ReferenceTestWithHandler();
                Logging.Info("Staring WITHOUT handler:");
                ReferenceTest();                            
            }
        }


        /// <summary>
        ///log4net log called Logging
        /// </summary>
        private static log4net.ILog Logging = 
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Test reference creation through unmanaged code.
        /// </summary>
        /// <returns>Reference result.</returns>
        public static int ReferenceTest()
        {
            try
            {
                // Attempt to create a reference through unmanaged code (C++ DLL).
                int result = CreateReference();
                // If no exception occurred, output successful result.
                Logging.Info($"Reference successfully created at: {result}.");
                // Return result.
                return result;
            }
            catch (System.AccessViolationException exception)
            {
                // Output explicit exception.
                Logging.Fatal(exception);
            }
            catch (BadImageFormatException exception)
            {
                Logging.Fatal(exception);
            }
            catch (Exception exception)
            {
                // Output inexplicit exception.
                Logging.Fatal(exception);
            }
            // Return zero to indicate failure.
            return 0;
        }

        /// <summary>
        /// Test reference creation through unmanaged code.
        /// HandleProcessCorruptedStateExceptions attribute allows CLR
        /// to catch normally ignored exceptions due to unmanaged code.
        /// </summary>
        /// <returns>Reference result.</returns>
        [HandleProcessCorruptedStateExceptions]
        public static int ReferenceTestWithHandler()
        {
            try
            {
                // Attempt to create a reference through unmanaged code (C++ DLL).
                var result = CreateReference();
                // If no exception occurred, output successful result.
                Logging.Info($"Reference successfully created at: {result}.");
                return result;
                //var addressIs = PleaseDoNotFailOnMe();
                //Logging.Info($"I made a reference. It's at: {addressIs} address");
                //return addressIs;
            }
            catch (System.AccessViolationException exception)
            {
                // Output explicit exception.
                Logging.Fatal(exception);
            }
            catch (Exception exception)
            {
                // Output inexplicit exception.
                Logging.Fatal(exception);
            }
            // Return zero to indicate failure.
            return 0;
        }
    }
}
