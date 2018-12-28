using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CtrlP.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string medidor,string tipoMedida, string valorLido)
        {
            /*
                Vai receber os dados do arduino, identificar qual medidor está enviando e atualizar o "grupo" relativo aquele medidor
             */
             //Clients.OthersInGroup(user).SendAsync(tipoMedida, valorLido);
             
            await Clients.All.SendAsync("ReceiveMessage", medidor,tipoMedida, valorLido);
        }
    }
}