using Galaxy.Client;

namespace GalaxyApi.Security
{
    public class UserStorage
    {
        private readonly ClusterClient clusterClient;

        public UserStorage(ClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
    }
}
