using UnityEngine;

namespace DI
{
    public class DIExampleScene : MonoBehaviour
    {
        public void Init(DIContainer projectContainer)
        {
            var sceneContainer = new DIContainer(projectContainer);
            sceneContainer.RegisterSingleton(c=>
                new MySceneService(c.Resolve<MyAwesomeProjectService>()));
            sceneContainer.RegisterSingleton(_ => new MyAwesomeFactory());
            sceneContainer.RegisterInstance(new MyAwesomeObject("instance", 10));

            var objectFactory = sceneContainer.Resolve<MyAwesomeFactory>();

            for (var i = 0; i < 3; i++)
            {
                var id = $"o{i}";
                var o = objectFactory.CreateInstance(id, i);
                Debug.Log($"Object created with factory.\n{o}");
            }

            var instance = sceneContainer.Resolve<MyAwesomeObject>();
            Debug.Log($"Object instance.\n{instance}");
        }
    }
}