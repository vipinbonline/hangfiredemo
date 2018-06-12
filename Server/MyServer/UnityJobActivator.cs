using System;
using Hangfire;
using Unity;

namespace MyServer
{

    public class UnityJobActivator : JobActivator
    {
        private readonly IUnityContainer _hangfireContainer;

        public UnityJobActivator(IUnityContainer hangfireContainer)
        {
            this._hangfireContainer = hangfireContainer;
        }

        public override object ActivateJob(Type type)
        {
            return _hangfireContainer.Resolve(type);
        }
    }
}