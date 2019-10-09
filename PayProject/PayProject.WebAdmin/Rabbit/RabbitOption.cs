using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayProject.WebAdmin.Rabbit
{
    public class RabbitOption
    {
        public RabbitOption(IConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var section = config.GetSection("rabbit");
            section.Bind(this);
        }

        public string Uri { get; set; }
    }
}
