﻿using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using System;

namespace LetsEncrypt
{
    public class KestrelOptionsSetup : IConfigureOptions<KestrelServerOptions>
    {
        private readonly CertificateSelector _certificateSelector;

        public KestrelOptionsSetup(CertificateSelector certificateSelector)
        {
            _certificateSelector = certificateSelector ?? throw new ArgumentNullException(nameof(certificateSelector));
        }

        public void Configure(KestrelServerOptions options)
        {
            options.ConfigureHttpsDefaults(o =>
            {
                o.ServerCertificateSelector = _certificateSelector.Select;
            });
        }
    }

}
