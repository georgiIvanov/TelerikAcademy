using BullsAndCows.Data;
using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Repository
{
    public class MessagesRepository : BaseRepository
    {
        public static IEnumerable<MessageModel> GetUnreadMessages(int userId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = context.Users.Include("Messages").FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user", "ERR_INV_USR");
                }
                
                var unreadMessageState = context.MessageStates.First(ms => ms.State == MessageStateUnread);
                var readMessageState = context.MessageStates.First(ms => ms.State == MessageStateRead);

                IEnumerable<Message> unreadMessages = user.Messages.Where(msg => msg.MessageState == unreadMessageState);
                var messageModels = ParseMessagesToModels(unreadMessages);

                foreach (var msg in unreadMessages)
                {
                    msg.MessageState = readMessageState;
                }
                context.SaveChanges();
                return messageModels;
            }
        }

        public static IEnumerable<MessageModel> GetAllMessages(int userId)
        {
            var context = new BullsAndCowsEntities();
            using (context)
            {
                var user = context.Users.Include("Messages").FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    throw new ServerErrorException("Invalid user", "ERR_INV_USR");
                }
                var messageModels = ParseMessagesToModels(user.Messages);
                var readMessageState = context.MessageStates.First(ms => ms.State == MessageStateRead);
                foreach (var msg in user.Messages)
                {
                    msg.MessageState = readMessageState;
                }
                context.SaveChanges();
                return messageModels;
            }
        }

        private static IEnumerable<MessageModel> ParseMessagesToModels(IEnumerable<Message> messages)
        {
            var models =
                        from msg in messages
                        select new MessageModel()
                        {
                            Text = msg.Text,
                            GameId = msg.Game.Id,
                            Type = msg.MessageType.Type,
                            State = msg.MessageState.State
                        };

            return models.ToList();
        }
    }
}