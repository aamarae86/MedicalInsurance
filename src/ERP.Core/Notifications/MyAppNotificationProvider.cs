using Abp.Authorization;
using Abp.Localization;
using Abp.Notifications;
using ERP.Authorization;

namespace ERP.Notifications
{
    public class MyAppNotificationProvider : NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    NotificationNames.NewStudyRequestPostedToManager
                    , displayName: new LocalizableString("NewStudyRequestPostedToManagerNotificationDefinition", "MyLocalizationSourceName")
                    , permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_ScPortalRequestMgrDecision)
                    )
                );
        }
    }
}
