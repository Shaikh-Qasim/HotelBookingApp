using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HotelBookingApp.Localization
{
    public static class HotelBookingAppLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HotelBookingAppConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HotelBookingAppLocalizationConfigurer).GetAssembly(),
                        "HotelBookingApp.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
