﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ElevenNote.API.Startup))]

namespace ElevenNote.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
