using UnityEngine;

namespace Db.Ai.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(NavMeshParameters), fileName = nameof(NavMeshParameters))]
    public class NavMeshParameters : ScriptableObject, INavMeshParameters
    {
        [SerializeField] private LayerMask _buildLayers;
        [SerializeField] private int _agentId;
        [SerializeField] private float _agentRadius;
        [SerializeField] private int _tournamentAgentId;
        [SerializeField] private float _tournamentAgentRadius;
        [SerializeField] private Bounds _bounds;

        public LayerMask BuildLayers => _buildLayers;
        public int AgentId => _agentId;

        public float AgentRadius => _agentRadius;

        public int TournamentAgentId => _tournamentAgentId;

        public float TournamentAgentRadius => _tournamentAgentRadius;

        public Bounds Bounds => _bounds;
    }
}