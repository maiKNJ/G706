using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class GameLogic
    {
        public static void Update()
        {
            foreach (Client _client in MyServer.clients.Values)
            {
                if (_client.player != null)
                {
                    _client.player.Update();
                }
            }
            ThreadManager.UpdateMain();
        }
    }
}
