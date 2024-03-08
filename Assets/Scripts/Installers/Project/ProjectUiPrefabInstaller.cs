using Game.Ui.Loading;
using SimpleUi;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ProjectUiPrefabInstaller), fileName = nameof(ProjectUiPrefabInstaller))]
    public class ProjectUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private LoadingView loadingView;
        
        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<LoadingController, LoadingView>(loadingView, canvasTransform);
        }
    }
}