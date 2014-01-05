using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace eUniversity.Business.AutoMapper
{
    /// <summary>
    /// Represents class for configuring automapper profiles
    /// </summary>
    public class AutomapperConfigurator
    {
        private readonly IEnumerable<Profile> profiles;

        public AutomapperConfigurator(IEnumerable<Profile> profiles)
        {
            this.profiles = profiles;
        }

        public void Configure()
        {
            Mapper.Initialize(configuration => profiles.ToList().ForEach(configuration.AddProfile));
        }
    }
}