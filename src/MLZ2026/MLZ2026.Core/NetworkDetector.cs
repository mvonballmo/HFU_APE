namespace MLZ2026.Core;

public class NetworkDetector : INetworkDetector
{
    public NetworkAccess NetworkAccess => Connectivity.NetworkAccess;
}