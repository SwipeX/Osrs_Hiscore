using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using Osrs_Hiscore.ViewModels;

namespace Osrs_Hiscore.Util
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();
            Parser.CreateTrigger = delegate(DependencyObject target, string triggerText)
            {
                System.Windows.Interactivity.EventTrigger eventTrigger;
                if (triggerText == null)
                {
                    var elementConvention = ConventionManager.GetElementConvention(target.GetType());
                    return elementConvention.CreateTrigger();
                }
                var eventName = triggerText.Replace("[", String.Empty).Replace("]", String.Empty);
                if (eventName.StartsWith("Delayed", StringComparison.OrdinalIgnoreCase))
                {
                    eventName = eventName.Replace("DelayedEvent", String.Empty).Trim();
                    eventTrigger = new DelayedEventTrigger();
                }
                else
                {
                    eventName = eventName.Replace("Event", string.Empty).Trim();
                    eventTrigger = new System.Windows.Interactivity.EventTrigger();
                }

                eventTrigger.EventName = eventName;
                return eventTrigger;
            };
            //DI setup
            container = new SimpleContainer();
            
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            
            container.Singleton<WindowViewModel>();
            container.Singleton<SideBarViewModel>();
            container.Singleton<ResultsViewModel>();
            container.Singleton<SearchViewModel>(); 
            container.Singleton<NotFoundViewModel>();
            container.Singleton<ResultsWrapViewModel>();

            container.PerRequest<ResultItemViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<WindowViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}