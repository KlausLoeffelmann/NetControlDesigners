using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TileRepeater.Data.Base
{
    /// <summary>
    /// Implementation of <see cref="INotifyPropertyChanged"/> to simplify models.
    /// </summary>
    public abstract class BindableBase : INotifyPropertyChanged
    {
        private bool _suspendUpdateNotifications;
        private bool _notificationOccured;

        /// <summary>
        /// Event for property change notification.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Creates an instance of the BindableBase class.
        /// </summary>
        public BindableBase(IServiceProvider? serviceProvider) : base()
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider? ServiceProvider { get; }

        /// <summary>
        /// Checks if a property already matches a desired value.  Sets the property and notifies
        /// listeners only when necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="storage">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="propertyName">Name of the property used to notify listeners.  This value
        /// is optional and can be provided automatically when invoked from compilers that support
        /// CallerMemberName.</param>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = default)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// </summary>
        /// <param name="propertyName">Name of the property used to notify listeners.  This value
        /// is optional and can be provided automatically when invoked from compilers that support
        /// <see cref="CallerMemberNameAttribute"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = default)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Indicates, that update notifications should be suspended.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        protected void SuspendUpdateNotifications()
        {
            if (_suspendUpdateNotifications)
            {
                throw new InvalidOperationException("Update Notifications are already suspended.");
            }
            _suspendUpdateNotifications = true;
            _notificationOccured = false;
        }

        /// <summary>
        /// Checkes, if notification have been suspended. This should be called, when a notification occured to check, if they have been suspended.
        /// </summary>
        /// <returns>true, if notifications are suspended.</returns>
        protected bool CheckForSuspendedUpdateNotifications()
        {
            _notificationOccured |= _suspendUpdateNotifications;
            return _suspendUpdateNotifications;
        }

        /// <summary>
        /// Resumes suspended notifications.
        /// </summary>
        /// <returns>True, if checks for suspended Notifications have been made, indicating notification occurance during suspension.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected bool ResumeNotifications()
        {
            if (!_suspendUpdateNotifications)
            {
                throw new InvalidOperationException("Update Notifications were not suspended.");
            }

            _suspendUpdateNotifications = false;

            return _notificationOccured;
        }
    }
}
