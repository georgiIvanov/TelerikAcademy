using BattleGame.Server.Data;
using BattleGame.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGame.Server.Persisters
{
    public class MessagesDataPersister : BattleGame.Server.Persisters.BaseDataPersister
    {
        public static IEnumerable<MessageModel> GetAllMessages(int userId)
        {
            var context = new BattleGameEntities();
            using (context)
            {
                var user = GetUser(userId, context);
                var messages = user.UserMessages;

                var messageModels =
                                   (from msg in messages
                                    select new MessageModel()
                                    {
                                        State = msg.MessageState.State,
                                        Text = msg.Text,
                                        GameId = (int)msg.Game.Id,
                                        GameTitle = msg.Game.Title,
                                        Type = msg.UserMessagesType.Type
                                    }).ToList();
                var readMessageState = context.MessageStates.First(st => st.State == "read");
                foreach (var msg in user.UserMessages)
                {
                    msg.MessageState = readMessageState;
                }
                context.SaveChanges();
                return messageModels;
            }
        }

        public static IEnumerable<MessageModel> GetUnreadMessages(int userId)
        {
            var messages = GetAllMessages(userId).Where(msg => msg.State == "unread");
            return messages;
        }
    }
}