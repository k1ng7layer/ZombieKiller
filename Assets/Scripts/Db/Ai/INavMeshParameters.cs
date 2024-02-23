using UnityEngine;

namespace Db.Ai
{
    public interface INavMeshParameters
    {
        LayerMask BuildLayers { get; }
        int AgentId { get; }
        float AgentRadius { get; }
        int TournamentAgentId { get; }
        float TournamentAgentRadius { get; }
        Bounds Bounds { get; }
    }
}