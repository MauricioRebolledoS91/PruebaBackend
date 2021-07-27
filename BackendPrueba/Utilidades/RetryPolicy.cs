using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendPrueba.Utilidades
{
    public static class RetryPolicy
    {
        public static IConfiguration _appConfig;

        public static AsyncRetryPolicy GetRetryPolicy(IConfiguration appConfig)
        {
            _appConfig = appConfig;
            var maxTrys = _appConfig.GetValue<int>("MaxTrys");
            var timeDelay = TimeSpan.FromSeconds(_appConfig.GetValue<int>("TimeDelay"));
            var retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(maxTrys, i => timeDelay);

            return retryPolicy;
        }
    }
}
