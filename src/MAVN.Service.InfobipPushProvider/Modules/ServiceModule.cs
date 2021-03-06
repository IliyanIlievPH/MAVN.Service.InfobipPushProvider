using Autofac;
using JetBrains.Annotations;
using MAVN.Service.InfobipPushProvider.Domain.Services;
using MAVN.Service.InfobipPushProvider.DomainServices;
using MAVN.Service.InfobipPushProvider.InfobipClient;
using MAVN.Service.InfobipPushProvider.Settings;
using Lykke.SettingsReader;

namespace MAVN.Service.InfobipPushProvider.Modules
{
    [UsedImplicitly]
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<AppSettings> _appSettings;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // Services
            builder.RegisterType<PushNotificationService>()
                .As<IPushNotificationService>()
                .SingleInstance()
                .WithParameter("fromSender", _appSettings.CurrentValue.Infobip.FromSender);

            // Clients
            builder.RegisterType<InfobipClient.InfobipClient>()
                .As<IInfobipClient>()
                .SingleInstance()
                .WithParameter("serviceUrl", _appSettings.CurrentValue.Infobip.ServiceUrl)
                .WithParameter("retries", _appSettings.CurrentValue.Infobip.Retries)
                .WithParameter("timeoutMs", _appSettings.CurrentValue.Infobip.TimeoutMs)
                .WithParameter("accessToken", _appSettings.CurrentValue.Infobip.Token);
        }
    }
}
