using System;
using System.Threading.Tasks;
using Abp;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;
using Abp.Notifications;
using Abp.RealTime;
using Castle.Core.Logging;
using Microsoft.AspNetCore.SignalR;

namespace ERP.Notifications
{
    public class MySignalRRealTimeNotifier : IRealTimeNotifier, ITransientDependency
    {
        /// <summary>
        /// Reference to the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        private readonly IOnlineClientManager _onlineClientManager;

        //private readonly IHubContext<MyAbpCommonHub> _hubContext;
        private readonly IHubContext<AbpCommonHub> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="MySignalRRealTimeNotifier"/> class.
        /// </summary>
        public MySignalRRealTimeNotifier(
            IOnlineClientManager onlineClientManager,
            IHubContext<AbpCommonHub> hubContext)
        //IHubContext<MyAbpCommonHub> hubContext)
        {
            _onlineClientManager = onlineClientManager;
            _hubContext = hubContext;
            Logger = NullLogger.Instance;
        }

        /// <inheritdoc/>
        public async Task SendNotificationsAsync(UserNotification[] userNotifications)
        {
            foreach (var userNotification in userNotifications)
            {
                try
                {
                    var onlineClients = _onlineClientManager.GetAllByUserId(userNotification);
                    var allOnlineClients = _onlineClientManager.GetAllClients();
                    foreach (var onlineClient in allOnlineClients)
                    {
                        string conId = onlineClient?.ConnectionId ?? "";
                        var signalRClient = _hubContext.Clients.Client(conId);
                        if (signalRClient == null)
                        {
                            Logger.Debug("Can not get user " + userNotification.ToUserIdentifier() + " with connectionId " + onlineClient.ConnectionId + " from SignalR hub!");
                            continue;
                        }

                        userNotification.Notification.EntityType = null; // Serialization of System.Type causes SignalR to disconnect. See https://github.com/aspnetboilerplate/aspnetboilerplate/issues/5230
                        await signalRClient.SendAsync("getNotification", userNotification);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn("Could not send notification to user: " + userNotification.ToUserIdentifier());
                    Logger.Warn(ex.ToString(), ex);
                }

                break;
            }
        }

        /// <inheritdoc/>
        public void SendNotifications(UserNotification[] userNotifications)
        {
            foreach (var userNotification in userNotifications)
            {
                try
                {
                    var onlineClients = _onlineClientManager.GetAllByUserId(userNotification);
                    foreach (var onlineClient in onlineClients)
                    {
                        var signalRClient = _hubContext.Clients.Client(onlineClient.ConnectionId);
                        if (signalRClient == null)
                        {
                            Logger.Debug("Can not get user " + userNotification.ToUserIdentifier() + " with connectionId " + onlineClient.ConnectionId + " from SignalR hub!");
                            continue;
                        }

                        userNotification.Notification.EntityType = null; // Serialization of System.Type causes SignalR to disconnect. See https://github.com/aspnetboilerplate/aspnetboilerplate/issues/5230
                        //signalRClient.SendAsync("getNotification", userNotification);
                        Abp.Threading.AsyncHelper.RunSync(() => signalRClient.SendAsync("getNotification", userNotification));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn("Could not send notification to user: " + userNotification.ToUserIdentifier());
                    Logger.Warn(ex.ToString(), ex);
                }
            }
        }
    }
}
