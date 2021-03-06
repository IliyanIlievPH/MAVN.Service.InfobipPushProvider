using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace MAVN.Service.InfobipPushProvider.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public InfobipPushProviderSettings InfobipPushProviderService { get; set; }

        public InfobipSettings Infobip { get; set; }
    }
}
