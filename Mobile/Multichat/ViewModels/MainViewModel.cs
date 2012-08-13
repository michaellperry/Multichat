using System;
using System.Linq;
using Multichat.Model;

namespace Multichat.ViewModels
{
    public class MainViewModel
    {
        private Individual _individual;
        private SynchronizationService _synhronizationService;

        public MainViewModel(Individual individual, SynchronizationService synhronizationService)
        {
            _individual = individual;
            _synhronizationService = synhronizationService;
        }

        public bool Synchronizing
        {
            get { return _synhronizationService.Synchronizing; }
        }
    }
}
