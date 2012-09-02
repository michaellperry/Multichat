using System;
using System.ComponentModel;
using System.Linq;
using UpdateControls.XAML;
using Multichat.Models;

namespace Multichat.ViewModels
{
    public class ViewModelLocator
    {
        private readonly SynchronizationService _synchronizationService;

        private readonly MessageBoardSelectionModel _selection;
        private readonly MainViewModel _main;
        private readonly SettingsViewModel _settings;
        private readonly JoinMessageBoardViewModel _join;
        private readonly SendMessageViewModel _send;

        public ViewModelLocator()
        {
            _synchronizationService = new SynchronizationService();
            if (!DesignerProperties.IsInDesignTool)
                _synchronizationService.Initialize();
            _selection = new MessageBoardSelectionModel();
            _main = new MainViewModel(_synchronizationService.Individual, _synchronizationService, _selection);
            _settings = new SettingsViewModel(_synchronizationService.Individual);
            _join = new JoinMessageBoardViewModel(_selection, _synchronizationService.Individual);
            _send = new SendMessageViewModel(_selection, _synchronizationService.Individual);
        }

        public object Main
        {
            get { return ForView.Wrap(_main); }
        }

        public object Settings
        {
            get { return ForView.Wrap(_settings); }
        }

        public object Join
        {
            get { return ForView.Wrap(_join); }
        }

        public object Send
        {
            get { return ForView.Wrap(_send); }
        }
    }
}
