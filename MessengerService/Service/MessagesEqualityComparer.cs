using System.Collections.Generic;
using MessengerService.Core.Models;

namespace MessengerService.Service;

public class MessagesEqualityComparer : IEqualityComparer<Message>
{
    public bool Equals(Message first, Message second)
    {
        if (ReferenceEquals(first, second)) 
            return true;

        if (first == null || second == null) 
            return false;

        return first.SenderNickname == second.SenderNickname
               && first.ReceiverNickname == second.ReceiverNickname
               && first.Text == second.Text
               && first.PostDateTime == second.PostDateTime;
    }

    public int GetHashCode(Message message)
    {
        return message.SenderNickname.GetHashCode()
               ^ message.ReceiverNickname.GetHashCode()
               ^ message.Text.GetHashCode()
               ^ message.PostDateTime.GetHashCode();
    }
}