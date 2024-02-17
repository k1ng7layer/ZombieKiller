using System;
using Game.Utils;
using UnityEngine;

namespace Db.ProjectileBase.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(ProjectileBase), fileName = "ProjectileBase")]
    public class ProjectileBase : ScriptableObject, IProjectileBase
    {
        [SerializeField] private Projectile[] _projectiles;
        
        public GameObject Get(EProjectileType projectileType)
        {
            foreach (var projectile in _projectiles)
            {
                if (projectile.ProjectileType == projectileType)
                    return projectile.Prefab;
            }
            
            throw new Exception($"[{typeof(ProjectileBase)}]: Can't find projectile with name: {projectileType}");
        }


        [Serializable]
        public class Projectile
        {
            public EProjectileType ProjectileType;
            public GameObject Prefab;
        }
    }
}