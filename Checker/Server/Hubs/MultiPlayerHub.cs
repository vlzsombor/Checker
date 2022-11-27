using Checker.Server.Data;
using Microsoft.AspNetCore.SignalR;

namespace Checker.Server.Hubs;

public class MultiPlayerHub : Hub
{
    private readonly TableManager tableManager;

    public MultiPlayerHub(TableManager tableManager)
    {
        this.tableManager = tableManager;
    }

    public async Task JoinTable(string tableId)
    {
        if (tableManager.Tables.ContainsKey(tableId))
        {
            if (tableManager.Tables[tableId] < 2)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, tableId);

                await Clients.GroupExcept(tableId, Context.ConnectionId).SendAsync("TableJoined");
                tableManager.Tables[tableId]++;

            }
        }
        else
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, tableId);
            tableManager.Tables.Add(tableId, 1);
        }


    }
    public async Task Move(string tableId, int previousColumn, int previousRow, int newCol, int newRow)
    {
        await Clients
            .GroupExcept(tableId, Context.ConnectionId)
            .SendAsync("Move",  previousRow, previousColumn, newRow, newCol);
    }

}
