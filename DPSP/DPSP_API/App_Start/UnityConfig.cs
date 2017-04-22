﻿using Microsoft.Practices.Unity;
using System;
using System.Configuration;
using System.Web;
using DPSP_BLL;
using DPSP_API.Controllers;

namespace DPSP_API
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterBusinessServices(container);
            return container;
        });


        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        //public static void RegisterTypes(IUnityContainer container)
        //{
        //}

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        private static void RegisterBusinessServices(IUnityContainer container)
        {
            container.RegisterType<IProjectService, ProjectService>();
        }


    }
}
