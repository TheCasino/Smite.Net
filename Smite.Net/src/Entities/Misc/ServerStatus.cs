using System;

namespace Smite.Net
{
    public sealed class ServerStatus
    {
        private readonly ServerStatusModel _model;

        /// <summary>
        /// If the servers have limited access.
        /// </summary>
        public bool IsLimitedAccess => _model.limited_access;

        /// <summary>
        /// The current status of the servers.
        /// </summary>
        public Status Status
        {
            get
            {
                switch(_model.status)
                {
                    case "UP":
                        return Status.Up;

                    case "DOWN":
                        return Status.Down;

                    default:
                        return Status.Unknown;
                }
            }
        }

        private DateTimeOffset _entryTime;

        /// <summary>
        /// The time of when this entry was made.
        /// </summary>
        public DateTimeOffset EntryTime => _entryTime == default
            ? _entryTime = DateTimeOffset.Parse(_model.entry_datetime)
            : _entryTime;

        /// <summary>
        /// The version of Smite that the servers are running.
        /// </summary>
        public string Version => _model.version;

        internal ServerStatus(ServerStatusModel model)
        {
            _model = model;
        }
    }
}
