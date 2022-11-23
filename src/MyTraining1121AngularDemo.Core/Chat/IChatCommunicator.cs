using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.RealTime;
using MyTraining1121AngularDemo.Friendships;

namespace MyTraining1121AngularDemo.Chat
{
    public interface IChatCommunicator
    {
        Task SendMessageToClient(IReadOnlyList<IOnlineClient> clients, ChatMessage message);

        Task SendFriendshipRequestToClient(IReadOnlyList<IOnlineClient> clients, Friendship friend, bool isOwnRequest, bool isFriendOnline);

        Task SendUserConnectionChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, bool isConnected);

        Task SendUserStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user, FriendshipState newState);

        Task SendAllUnreadMessagesOfUserReadToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user);

        Task SendReadStateChangeToClients(IReadOnlyList<IOnlineClient> onlineFriendClients, UserIdentifier user);
    }
}
