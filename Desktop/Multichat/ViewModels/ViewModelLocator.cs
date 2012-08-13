using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using UpdateControls.XAML;
using Multichat.Models;

namespace Multichat.ViewModels
{
    public class ViewModelLocator
    {
        private readonly SynchronizationService _synchronizationService;

        private readonly MainViewModel _main;

        public ViewModelLocator()
        {
            _synchronizationService = new SynchronizationService();
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                _synchronizationService.Initialize();

            MessageBoardSelectionModel messageBoardSelectionModel = new MessageBoardSelectionModel();
            _main = new MainViewModel(_synchronizationService.Community, messageBoardSelectionModel, _synchronizationService);
        }

        public object Main
        {
            get { return ForView.Wrap(_main); }
        }
    }
}
