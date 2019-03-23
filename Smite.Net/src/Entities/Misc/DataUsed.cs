using System;

namespace Smite.Net
{
    public sealed class DataUsed
    {
        private readonly DataUsedModel _model;

        /// <summary>
        /// Your current amount of active sessions.
        /// </summary>
        public int ActiveSessions => _model.Active_Sessions;

        /// <summary>
        /// How many active sessions you can have.
        /// </summary>
        public int ConcurrentSessions => _model.Concurrent_Sessions;

        /// <summary>
        /// The number of requests you're allowed to make daily.
        /// </summary>
        public int RequestDailyLimit => _model.Request_Limit_Daily;

        /// <summary>
        /// The number of sessions you're allowed to create in a day.
        /// </summary>
        public int SessionCap => _model.Session_Cap;

        /// <summary>
        /// The number of requests you have made today.
        /// </summary>
        public int RequestsToday => _model.Total_Requests_Today;

        /// <summary>
        /// The number of sessions you've created today.
        /// </summary>
        public int SessionsToday => _model.Total_Sessions_Today;


        private TimeSpan _sessionTimeoutLimit;

        /// <summary>
        /// The timelimit for each session.
        /// </summary>
        public TimeSpan SessionTimeLimit => _sessionTimeoutLimit == default
            ? _sessionTimeoutLimit = TimeSpan.FromMinutes(_model.Session_Time_Limit)
            : _sessionTimeoutLimit;

        internal DataUsed(DataUsedModel model)
        {
            _model = model;
        }
    }
}
