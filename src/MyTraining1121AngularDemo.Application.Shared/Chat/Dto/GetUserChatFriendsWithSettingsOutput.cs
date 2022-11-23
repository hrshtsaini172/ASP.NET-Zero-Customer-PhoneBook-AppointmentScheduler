using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using MyTraining1121AngularDemo.Friendships.Dto;

namespace MyTraining1121AngularDemo.Chat.Dto
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }
        
        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}