using System;
using Unity.VisualScripting;

namespace DI
{
    public class DIRegistration
    {
        public Func<DIContainer, object> Factory { get; set; }
        public bool IsSingleton { get; set; }
        public object Instanse { get; set; }
    }
}